import { Component, OnInit,Injectable, Pipe } from '@angular/core'
import { from, Observable } from 'rxjs'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { environment } from '../../environments/environment'
// import { DateRangeOfWeek } from './periods'
import {RestAPIService} from '../api-service/ApiService'
import {NgbModal} from '@ng-bootstrap/ng-bootstrap'

declare const GetWeekArr: any
declare const validateRowReasonSelect: any
declare const validateRowCheck: any

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
  data:any
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

  constructor(private restApiService: RestAPIService) { }

  ngOnInit(): void {
    this.sendGetRequest()
  }
  sendGetRequest(){
    this.restApiService.GetPlantId().subscribe((result)=>{ 
      this.PlantVal  =  result
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
      this.data = result[0]
      this.ReasonCode = result[1]
    })
  }
  selectReason(e:any, ind:any, dat:any){
    var selData = validateRowReasonSelect(e, ind, dat, this.MetricId)
    if(selData){
      this.selectedRow.push(selData)
    }
  }
  selectHit(e:any, ind:any, dat:any){
    var checkedRow = validateRowCheck(e, ind, dat, this.MetricId)
    if(checkedRow){
      this.selectedRow.push(checkedRow)
    }
  }
  reasonSave(){
    if(this.selectedRow != ''){
      let saveData = {​​​​​​​
        "shopFloorMetricDetails": this.selectedRow
      }​​​​​​​
      this.restApiService.SaveData(saveData).subscribe((result)=>{ 
        this.SaveMessage = "Record has been updated successfully !"
      })
    }
  }
}
