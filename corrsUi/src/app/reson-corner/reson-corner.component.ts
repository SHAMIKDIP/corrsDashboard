import { Component, OnInit,Injectable, Pipe } from '@angular/core'
import { from, Observable } from 'rxjs'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from '../../environments/environment'
// import { DateRangeOfWeek } from './periods'
import {RestAPIService} from '../api-service/ApiService'
import { CommonModal } from '../modal/Modal'

declare const GetWeekArr: any
declare const validateRowReasonSelect: any
declare const validateRowCheck: any
declare const FilterData: any

@Component({
  selector: 'app-reson-corner',
  templateUrl: './reson-corner.component.html',
  styleUrls: ['./reson-corner.component.css']
})
@Injectable()
export class ResonCornerComponent implements OnInit {
  url:any = environment.url
  Plant:any
  Metric:any
  Period:any
  ReasonCode:any
  WeekLabel:any
  PlantErr:boolean=false
  MetricErr:boolean=false
  PeriodErr:boolean=false
  data:any = null
  DataSaveArr:any
  MetricId:any
  PlantVal:any
  MetricVal:any
  PeriodVal:any
  OnErrorReason:boolean=false
  OnErrorCheck:boolean=false
  dtOptions: any = {
    pagingType: 'full_numbers',
    pageLength: 5,
    lengthMenu : [5, 10, 15],
    processing: true,
    "searching": false
  }
  selectedRow:any = []
  SaveMessage:string = ''
  PlantFilter:any
  SaveDataArr:any = []
  NoSelect:boolean = false
  SaveMessageErr:string = ''
  MessageSuccessModal:string = ''
  MessageErrorModal:string = ''

  constructor(private restApiService: RestAPIService, private CommonModal: CommonModal) { }

  ngOnInit(): void {
    this.sendGetRequest()
  }
  sendGetRequest(){
    this.restApiService.GetPlantId().subscribe((result)=>{ 
      this.PlantVal  =  result
      let newVal = FilterData(this.PlantVal)
      newVal = newVal.filter((item, index) => newVal.indexOf(item) === index)
      this.PlantFilter = newVal
    })
    var result = this.getWeekNumber(new Date())
    var range = GetWeekArr(result)    
    this.PeriodVal = range
  }
  getWeekNumber(d:any) {
    d = new Date(Date.UTC(d.getFullYear(), d.getMonth(), d.getDate()))
    d.setUTCDate(d.getUTCDate() + 4 - (d.getUTCDay()||7))
    var yearStart:any = new Date(Date.UTC(d.getUTCFullYear(),0,1))
    var weekNo = Math.ceil(( ( (d - yearStart) / 86400000) + 1)/7)
    return [d.getUTCFullYear(), weekNo];
  }
  selectChange(e:any,code:any){
    if(code === 1){
      this.Plant = e.target.value
      this.MetricVal = this.PlantVal.filter(reason => reason.plantId === this.Plant)
    }
    if(code === 2){
      this.Metric = e.target.value
      let getMetric = this.MetricVal.filter(mId => mId.metricName === e.target.options[e.target.options.selectedIndex].text)
      this.MetricId = getMetric[0].metricId
    }
    if(code === 3){
      this.Period = e.target.value
      this.WeekLabel = e.target.options[e.target.selectedIndex].text
    }
    this.ValidateForm()
  }
  ValidateForm(){
    if(this.Plant == '' || this.Plant == undefined){
      this.PlantErr = true
    }else{
      this.PlantErr = false
    }

    if(this.Metric == '' || this.Metric == undefined){
      this.MetricErr = true
    }else{
      this.MetricErr = false
    }

    if(this.Period == '' || this.Period == undefined){
      this.PeriodErr = true
    }else{
      this.PeriodErr = false
    }
  }
  SubmitForm(){
    this.ValidateForm()
    if(this.PlantErr || this.MetricErr || this.PeriodErr){
      return false
    }
    let obj = {
      "plantid": this.Plant,
      "week": parseInt(this.Period),
      "metricid": this.MetricId
    }
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      })
    }
    this.restApiService.GetMissedOrders(obj).subscribe((result)=>{ 
      if(result){
        this.data = result[0] == '' ? null : result[0]
        this.ReasonCode = result[1]
      }else{
        this.data = null
      }
    })
  }
  selectReason(e:any, ind:any, dat:any){
    let name = 'check'+ind
    this.selectedRow = this.selectedRow.filter(reason => reason.IDCheck != name)
    this.selectedRow.push({
      "resource": dat.resource,
      "flag": validateRowReasonSelect(e, ind, dat, this.MetricId),
      "processOrder":dat.processOrder,
      "ReasonCodeId": e.target.value,
      "MetricId":this.MetricId,
      "IDCheck": 'check'+ind,
      "IdSel": 'select'+ind
    })
  }
  selectHit(e:any, ind:any, dat:any){
    let name = 'check'+ind
    this.selectedRow = this.selectedRow.filter(reason => reason.IDCheck != name)
    this.selectedRow.push({
      "resource": dat.resource,
      "flag": e.target.checked ? "Hit" : "Miss",
      "processOrder":dat.processOrder,
      "ReasonCodeId": validateRowCheck(e, ind, dat, this.MetricId),
      "MetricId":this.MetricId,
      "IDCheck": 'check'+ind,
      "IdSel": 'select'+ind
    })
  }

  reasonSave(){
    if(this.selectedRow != ''){
      let d = []
      for(let e = 0;e<this.selectedRow.length;e++){
        d.push(
          {
            "resource":this.selectedRow[e].resource,
            "flag":this.selectedRow[e].flag,
            "processOrder":this.selectedRow[e].processOrder,
            "ReasonCodeId": this.selectedRow[e].ReasonCodeId ? parseInt(this.selectedRow[e].ReasonCodeId) : null,
            "MetricId":this.selectedRow[e].MetricId,
            "reasoncornerflag": this.selectedRow[e].flag == 'Hit' ? 1 : 0
          }
        )
      }
      // console.log(d)
      let saveData = {​​​​​​​
        "shopFloorMetricDetails": d
      }​​​​​​​
      this.MessageSuccessModal = ''
      this.MessageErrorModal = ''
      this.restApiService.SaveData(saveData).subscribe((result) => {
        this.MessageSuccessModal = d.length + ' Record has been updated successfully !'
        document.getElementById('openModal').click()
        setTimeout (() => {
          this.selectedRow = []
        }, 100)
      },(error) => {
        this.MessageErrorModal = 'Something went wrong. Please try again later'
        document.getElementById('openModal').click()
      })
    }else{
      this.NoSelect = true
    }
  }
  open(content:any){
    this.CommonModal.open(content)
  }
}
