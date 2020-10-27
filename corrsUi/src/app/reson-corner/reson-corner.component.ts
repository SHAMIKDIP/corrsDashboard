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
declare const DatePicker:any
declare const GetWeek:any
declare const GetWeekLabel:any

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
    "searching": false,
    "columnDefs": [{ targets: 'no-sort', orderable: false }],
    "order": [[ 5, "desc" ]]//asc
  }
  selectedRow:any = []
  SaveMessage:string = ''
  PlantFilter:any
  SaveDataArr:any = []
  NoSelect:boolean = false
  SaveMessageErr:string = ''
  MessageSuccessModal:string = ''
  MessageErrorModal:string = ''
  Loading:boolean = false
  ErrCount:number = 0
  Weekval:any = ''
  UserData:any

  constructor(private restApiService: RestAPIService, private CommonModal: CommonModal) { }

  ngOnInit(): void {
    this.Loading = true
    this.sendGetRequest()
    DatePicker()
    // this.restApiService.GetUserService().subscribe((result)=>{

    // },(error)=>{
    //   this.UserData = {
    //     "Name": 'Binu',
    //     "Role": 'Admin'
    //   }
    //   console.log(this.UserData)
    // })
  }
  sendGetRequest(){
    this.restApiService.GetPlantId().subscribe((result)=>{ 
      this.PlantVal  =  result
      let newVal = FilterData(this.PlantVal)
      newVal = newVal.filter((item, index) => newVal.indexOf(item) === index)
      this.PlantFilter = newVal
      this.Loading = false
    },(error) => {
      this.SuccessModal(0,0)
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
    this.ValidateForm()
  }
  ValidateForm(){
    this.Period = GetWeek()
    this.WeekLabel = GetWeekLabel()
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
    this.Loading = true
    this.data = null
    this.restApiService.GetMissedOrders(obj).subscribe((result)=>{ 
      if(result){
        this.data = result[0] == '' ? null : result[0]
        this.ReasonCode = result[1]
      }else{
        this.data = null
      }
      this.Loading = false
    },(error) => {
      this.SuccessModal(0, 0)
    })
  }

  selectHit(e:any, ind:any, dat:any, f:any){
    console.log(this.Weekval)
    let reasonCodId = dat.reasonCodeId || ''
    let selectVal = validateRowCheck(ind)
    let checkVal = validateRowReasonSelect(ind)
    let IDCheck = 'check'+ind
    let IdSel = 'select'+ind
    let reasonCornerFlag = dat.reasonCornerFlag == 1 ? 'Hit' : 'Miss'
    console.log("IDCheck ", checkVal)
    console.log("IdSel ", selectVal)
    if(f == 'select'){
      selectVal = e.target.value
    }else{
      checkVal = e.target.checked ? 'Hit' : 'Miss'
    }
    this.selectedRow = this.selectedRow.filter(reason => reason.IdSel != IdSel)
    if(selectVal == reasonCodId && checkVal == reasonCornerFlag){
      let elmt = document.getElementById('select'+ind)
      elmt.classList.remove('error')
      this.ErrCount = this.ErrCount > 0 ? this.ErrCount - 1 : this.ErrCount
    }else{
      if(checkVal == "Hit" && selectVal == ''){
        let elmt = document.getElementById('select'+ind)
        elmt.classList.add('error')
        this.ErrCount = this.ErrCount + 1
      }else{
        let elmt = document.getElementById('select'+ind)
        elmt.classList.remove('error')
        this.ErrCount = this.ErrCount > 0 ? this.ErrCount - 1 : this.ErrCount
        this.selectedRow.push({
          "resource": dat.resource,
          "flag": checkVal,
          "processOrder":dat.processOrder,
          "ReasonCodeId": selectVal,
          "MetricId":this.MetricId,
          "IDCheck": IDCheck,
          "IdSel": IdSel
        })
      }
    }
  }

  reasonSave(){
    if(this.selectedRow != ''){
      if(this.ErrCount > 0){
        this.SuccessModal(2,this.ErrCount)
      }else{
        console.log(this.ErrCount)
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
        let saveData = {​​​​​​​
          "shopFloorMetricDetails": d
        }​​​​​​​
        this.MessageSuccessModal = ''
        this.MessageErrorModal = ''
        this.restApiService.SaveData(saveData).subscribe((result) => {
          this.SubmitForm()
          this.selectedRow = []
          this.SuccessModal(1, d.length)
        },(error) => {
          this.SuccessModal(0, 0)
        })
      }
    }else{
      this.NoSelect = true
    }
  }
  open(content:any){
    this.CommonModal.open(content)
  }

  SuccessModal(sts:any, num:any){
    this.MessageSuccessModal = ''
    this.MessageErrorModal = ''
    this.Loading = false
    if(sts == 1){
      this.MessageSuccessModal = num + ' Record has been updated successfully !'
    }else if(sts == 2){
      this.MessageErrorModal = 'Please fill all mandatory fields before save'
    }else{
      this.MessageErrorModal = 'Something went wrong. Please try again later'
    }
    document.getElementById('openModal').click()
  }
}
