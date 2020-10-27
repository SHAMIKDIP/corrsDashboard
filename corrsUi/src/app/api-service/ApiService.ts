import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs'
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})

export class RestAPIService {

  UserData:any
  private api = environment.url
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  StoreData(data:any):Observable<any>{
    this.UserData = data
    return this.UserData
  }

  GetData():Observable<any>{
    return this.UserData
  }

  GetUserService():Observable<any>{
    return this.httpClient.get(this.api+'/userservice/getuser')
    // return this.httpClient.get(this.api+'/userservice/getuser')
  }

  GetPlantId(): Observable<any> {
    return this.httpClient.get(this.api+'/Metricsview/GetAllPlantID')
  }

  GetMissedOrders(data:any): Observable<any>{
    return this.httpClient.post(this.api+'/ShopFloorComformance/Displaymissedorders',data)
  }

  SaveData(data:any): Observable<any>{
    return this.httpClient.put(this.api+'/ShopFloorComformance/UpdateShopFloor',data)
  }

  GetReasonCode():Observable<any>{
    return this.httpClient.get(this.api+"/AddReasonCode/Getallreasoncode")
  }

  SaveReasonCode(data:any): Observable<any>{
    return this.httpClient.post(this.api+'/AddReasonCode/AddNewReasoncode',data)
  }

  EnableReasonSave(data:any):Observable<any>{
    return this.httpClient.put(this.api+'/AddReasonCode/Reasoncodeupdate',data)
  }

  GetPlantData():Observable<any>{
    return this.httpClient.get(this.api+'/Corrsplants/GetAllPlantID')
  }

  EnablePlants(data:any):Observable<any>{
    return this.httpClient.put(this.api+'/Corrsplants/plantidUpdate', data)
  }

  AddNewPlant(data:any):Observable<any>{
    return this.httpClient.post(this.api+'/Corrsplants/Createnewplant', data)
  }

}