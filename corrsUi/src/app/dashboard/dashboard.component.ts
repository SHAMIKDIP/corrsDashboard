import { Component, OnInit } from '@angular/core';
import {RestAPIService} from '../api-service/ApiService'

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private restApiService: RestAPIService) { }

  ngOnInit(): void {

  }

}
