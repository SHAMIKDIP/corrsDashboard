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
  dtOptions: any = {
    pagingType: 'full_numbers',
    pageLength: 5,
    lengthMenu : [5, 10, 15],
    processing: true,
    "searching": false
  }

  constructor(private restApiService: RestAPIService) { }

  ngOnInit(): void {
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
    console.log(this.ReasonCodeList)
  }
  selectHit(e:any){

  }
  reasonSave(){
    
  }
  saveReason(){
    console.log('save')
  }
}
