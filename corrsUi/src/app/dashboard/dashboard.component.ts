import { Component, OnInit } from '@angular/core';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';
import {RestAPIService} from '../api-service/ApiService'
import { CommonModal } from '../modal/Modal'

declare const FilterPlantData:any

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  ReasonCodeData:any
  ReasonCodeList:any = ''
  FilterValue:any = ''
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
  PlantEmptyCheck:any = ''
  MessageModal:string = ''
  MessageSuccessModal:string = ''
  MessageErrorModal:string = ''
  PlantData:any = ''
  PlantSelected:any = []
  Loading:boolean = false
  PlantDomain:any
  PlantIdName:any
  PlantIdNameErr:any = ''
  PlantIdNameErrBol:boolean = false

  constructor(private restApiService: RestAPIService, private CommonModal: CommonModal) { }

  ngOnInit(): void {
    this.Loading = true
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
      this.Loading = false
    },(error)=>{
      this.SuccessModal(0,0)
    })
  }

  selectMetricName(e:any){
    let metricNaveVal = e.target.value
    this.ReasonCodeList = ''
    this.Loading = true
    setTimeout(() => {
      this.ReasonCodeList = this.ReasonCodeData.filter(list => list.metricName === metricNaveVal)
      this.Loading = false
    },500);
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
        "MetricName": d,
        "flag" : e.target.checked ? 1 : 0
      })
    }else{
      this.SelectMetricCheck = this.SelectMetricCheck.filter(list => list.MetricName != d)
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
        "reasoncodename": this.ReasonText,
        "MetricreasoncodeviewDetails": this.SelectMetricCheck
      }
      this.restApiService.SaveReasonCode(this.SaveReasonData).subscribe((result) => {
        this.SuccessModal(2,0)
      },(error) => {
        if(error.error.text){
          this.SuccessModal(error.error.text,0)
        }else{
          this.SuccessModal(0,0)
        }
      })
    }
  }
  enableReasonSave(){
    if(this.EnableSaveData != ''){
      let d = {
        "MetricDetails": this.EnableSaveData
      }
      this.Loading = true
      this.restApiService.EnableReasonSave(d).subscribe((result) => {
        this.SuccessModal(3,0)
        this.EnableSaveData = []
      },(error) => {
        this.SuccessModal(0,0)
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
    this.PlantText = e.target.value
    this.PlantValid(this.PlantText)
  }
  PlantIdChange(e:any){
    this.PlantIdName = e.target.value
    if(this.PlantIdName == ''){
      this.PlantIdNameErr = 'Please enter plant domain'
      this.PlantIdNameErrBol = true
    }else{
      this.PlantIdNameErr = ''
      this.PlantIdNameErrBol = false
    }
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
  selectPlantMetric(e:any){
    this.PlantMetric = e.target.value
    if(this.PlantMetric == ''){
      this.PlantEmptyCheck = 'Please select a Domain'
    }else{
      this.PlantEmptyCheck = ''
    }
  }
  open(content:any){
    this.CommonModal.open(content)
  }
  PlantSave(){
    if(this.PlantText == ''){
      this.PlantValid(this.PlantText)
    }else if(this.PlantIdName == '' || this.PlantIdName == undefined){
      this.PlantIdNameErrBol = true
      this.PlantIdNameErr = 'Please enter plant domain'
    }else if(this.PlantMetric == ''){
      this.PlantEmptyCheck = "Please select a Domain"
    }else{
      this.Loading = true
      let d = {
        "PlantId":this.PlantIdName,
        "PlantDomain":this.PlantMetric,
        "PlantName":this.PlantText
      }
      
      this.restApiService.AddNewPlant(d).subscribe((result)=>{
        this.SuccessModal(1,0)
      },(error) => {
        // if(error){
        //   this.SuccessModal(error.error.text,0)
        // }else{
          this.SuccessModal(0,0)
        // }
      })
    }
  }

  GetPlant(){
    this.restApiService.GetPlantData().subscribe((result) =>{
      this.PlantData = result
      let dmianVal = FilterPlantData(this.PlantData)
      let newVal = dmianVal.filter((item, index) => dmianVal.indexOf(item) === index)
      this.PlantDomain = newVal
      console.log(this.PlantDomain)
    })  
  }
  
  enablePlant(e:any, i:any, d:any){
    this.PlantSelected = this.PlantSelected.filter(fi => fi.PlantId != d.plantId)
    this.PlantSelected.push({
      "Flag": e.target.checked ? 1 : 0,
      "PlantId": d.plantId
    })
  }

  enablePlantSave(){
    let d = {
      "getCorrsplantlist":this.PlantSelected
    }
    this.Loading = true
    this.restApiService.EnablePlants(d).subscribe((result) => {
      this.SuccessModal(3,this.PlantSelected.length)
      this.PlantSelected = []
    },(error) => {
      this.SuccessModal(0,0)
    })
  }

  SuccessModal(sts:any, num:any){
    this.MessageSuccessModal = ''
    this.MessageErrorModal = ''
    this.Loading = false
    if(sts == 1){
      this.MessageSuccessModal = num + ' Record has been updated successfully !'
    }else if(sts == 2){
      this.MessageSuccessModal = 'Reason name saved successfully !'
    }else if(sts == 3){
      this.MessageSuccessModal = 'Selected records has been updated successfully !'
    }else if(sts == 0){
      this.MessageErrorModal = 'Something went wrong. Please try again later'
    }else{
      this.MessageErrorModal = sts
    }
    document.getElementById('openModal').click()
  }

}
