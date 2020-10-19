import { Component, OnInit } from '@angular/core';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import {RestAPIService} from '../api-service/ApiService'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  ReasonCodeData:any
  ReasonCodeList:any
  FilterValue:any
  SaveMessage:string
  ReasonText:string = ''
  ReasonTextErr:string
  ReasonTextErrBol:boolean = false
  SaveReasonData:any
  SelectMetricCheck:any = []
  dtOptions: any = {
    pagingType: 'full_numbers',
    pageLength: 5,
    lengthMenu : [5, 10, 15],
    processing: true,
    "searching": false
  }
  MetricSelect:boolean = false
  SaveSuccess:boolean = false
  EnableSaveData:any = []
  EnableSucces:boolean = false
  ResonSelect:boolean = false

  constructor(private restApiService: RestAPIService) { }

  ngOnInit(): void {
    this.GetMetricName()
  }
  GetMetricName(){
    this.FilterValue = []
    this.ReasonCodeList = []
    this.restApiService.GetReasonCode().subscribe((result)=>{ 
      this.ReasonCodeData = result
      var e = []
      for(let i=0;i<this.ReasonCodeData.length;i++){
        var j = this.ReasonCodeData[i].metricName
        e.push(j)
      }
      this.FilterValue = e.filter((item, index) => e.indexOf(item) === index)
    })
  }

  selectMetricName(e:any){
    let metricNaveVal = e.target.value
    this.ReasonCodeList = this.ReasonCodeData.filter(list => list.metricName === metricNaveVal)
  }
  ReasonTextareaChange(e:any){
    this.ReasonText =e.target.value
    this.ReasonEmptyCheck(this.ReasonText)
  }
  ReasonEmptyCheck(d:any){
    if(d == ''){
      this.ReasonTextErr = 'Please enter a reason name'
      this.ReasonTextErrBol = true
    }else{
      this.ReasonTextErr = ''
      this.ReasonTextErrBol = false
    }
  }
  enableReason(e:any, i:any, d:any){
    let v = e.target.checked
    this.EnableSaveData = this.EnableSaveData.filter(list => list.Reasoncodeid != d.reasonCodeId)
    this.EnableSaveData.push({
      "flag": v ? 1 : 0,
      "Reasoncodeid": d.reasonCodeId
    })
    this.ResonSelect = false
  }
  selectMetric(e:any, i:any, d:any){
    let nl = d
    let  nr = this.ReasonCodeData.filter(list => list.metricName === nl)
    if(e.target.checked){
      this.SelectMetricCheck.push({
        "flag": e.target.checked ? 1 : 0,
        "metricid": nr[0].metricId,
        "reasoncode": this.ReasonText,
        "Metricname": nr[0].metricName
      })
    }else{
      this.SelectMetricCheck = this.SelectMetricCheck.filter(list => list.Metricname != nl)
    }
    if(this.SelectMetricCheck != ''){
      this.MetricSelect = false
    }
  }
  reasonSave(){
    if(this.ReasonText == ''){
      this.ReasonEmptyCheck(this.ReasonText)
    }else if(this.SelectMetricCheck == ''){
      this.MetricSelect = true
    }else{
      this.SaveReasonData = {
        "MetricbasedreasoncodeviewDetails": this.SelectMetricCheck
      }
      this.restApiService.SaveReasonCode(this.SaveReasonData).subscribe(res => {
        this.SaveSuccess = true
        setTimeout (() => {
          this.SaveSuccess = false
        }, 10000)
      })
    }
    
  }
  enableReasonSave(){
    // if(this.EnableSaveData != ''){
      let d = {
        "ReasonCodeList": this.EnableSaveData
      }
      this.restApiService.EnableReasonSave(d).subscribe(res => {
        this.EnableSucces = true
        setTimeout (() => {
          this.EnableSucces = false
        }, 3000)
      })
    // }else{
    //   this.ResonSelect = true
    // }
  }

  changeTab(t:any){
    if(t == 1){
      this.GetMetricName()
    }
  }
}
