import { Component, OnInit } from '@angular/core';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import {RestAPIService} from '../api-service/ApiService'
import { CommonModal } from '../modal/Modal'

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
  PlantTextErr:string = ''
  PlantTextErrBol:boolean = false
  PlantText:string = ''
  PlantMetric:any = []
  PlantEmptyCheck:boolean = false
  MessageModal:string = ''
  MessageSuccessModal:string = ''
  MessageErrorModal:string = ''
  PlantData:any
  PlantSelected:any = []

  constructor(private restApiService: RestAPIService, private CommonModal: CommonModal) { }

  ngOnInit(): void {
    this.GetMetricName()
    this.GetPlant()
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
      "Flag": v ? 1 : 0,
      "ReasonId": d.reasonCodeId,
      "MetricId": d.metricId
    })
    this.ResonSelect = false
  }
  selectMetric(e:any, i:any, d:any){
    let nl = d
    let  nr = this.ReasonCodeData.filter(list => list.metricName === nl)
    if(e.target.checked){
      this.SelectMetricCheck.push({
        "MetricId": nr[0].metricId,
        "ReasonCode": this.ReasonText
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
      this.MessageSuccessModal = ''
      this.MessageErrorModal = ''
      this.restApiService.SaveReasonCode(this.SaveReasonData).subscribe((result) => {
        this.MessageSuccessModal = 'Reason name saved successfully!'
        document.getElementById('openModal').click()
      },(error) => {
        this.MessageErrorModal = 'Something went wrong. Please try again later'
        document.getElementById('openModal').click()
      })
    }
  }
  enableReasonSave(){
    if(this.EnableSaveData != ''){
      let d = {
        "ReasonCodeList": this.EnableSaveData
      }
      this.MessageSuccessModal = ''
      this.MessageErrorModal = ''
      this.restApiService.EnableReasonSave(d).subscribe((result) => {
        this.MessageSuccessModal = 'Selected reason names are updated successfully!'
        document.getElementById('openModal').click()
      },(error) => {
        this.MessageErrorModal = 'Something went wrong. Please try again later'
        document.getElementById('openModal').click()
      })
    }else{
      this.ResonSelect = true
    }
  }

  changeTab(t:any){
    if(t == 1){
      this.GetMetricName()
    }
  }
  PlantTextareaChange(e:any){
    // PlantTextErr:string = ''
    // PlantTextErrBol:boolean = false
    this.PlantText = e.target.value
    this.PlantValid(this.PlantText)
  }
  PlantValid(t:any){
    if(t == ''){
      this.PlantTextErr = 'Please add a plant name'
      this.PlantTextErrBol = true
    }else{
      this.PlantTextErr = ''
      this.PlantTextErrBol = false
    }
  }
  selectPlantMetric(e:any, i:any, d:any){
    if(e.target.checked){
      this.PlantMetric.push({"plantName": d})
    }else{
      this.PlantMetric = this.PlantMetric.filter(j => j.plantName != d)
    }
    if(this.PlantMetric == '' && this.PlantText == ''){
      this.PlantEmptyCheck = false
    }else if(this.PlantMetric != '' && this.PlantText != ''){
      this.PlantEmptyCheck = false
    }else{
      this.PlantEmptyCheck = true
    }
  }
  open(content:any){
    this.CommonModal.open(content)
  }
  PlantSave(){
    // this.MessageModal = 'Something went wrong'
    // document.getElementById('openModal').click()
    if(this.PlantText == ''){
      this.PlantValid(this.PlantText)
    }else if(this.PlantMetric == ''){
      this.PlantEmptyCheck = true
    }else{
      console.log(this.PlantText, this.PlantMetric)
    }
  }

  GetPlant(){
    this.restApiService.GetPlantData().subscribe((result) =>{
      this.PlantData = result
      console.log(this.PlantData)
    })  
  }
  
  enablePlant(e:any, i:any, d:any){
    debugger
    this.PlantSelected = this.PlantSelected.filter(fi => fi.PlantId != d.plantId)
    this.PlantSelected.push({
      "Flag": e.target.checked ? 1 : 0,
      "PlantId": d.plantId
    })
  }

  enablePlantSave(){
    console.log(this.PlantSelected)
    let d = {
      "corrsPlantList":this.PlantSelected
    }
    this.MessageSuccessModal = ''
    this.MessageErrorModal = ''
    this.restApiService.EnablePlants(d).subscribe((result) => {
      this.MessageSuccessModal = 'Selected Plants are updated successfully!'
      document.getElementById('openModal').click()
      this.PlantSelected = []
    },(error) => {
      this.MessageErrorModal = 'Something went wrong. Please try again later'
      document.getElementById('openModal').click()
        debugger
    })
  }

}
