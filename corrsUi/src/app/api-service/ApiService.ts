import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs'
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})

export class RestAPIService {

  private api = environment.url
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpClient: HttpClient) { }

  GetPlantId(): Observable<any> {
    return this.httpClient.get(this.api+'/Metricsview/GetAllPlantID')
  }

  GetMissedOrders(data:any): Observable<any>{
    return this.httpClient.post(this.api+'/ShopFloorComformance/Displaymissedorders',data)
  }

  SaveData(data:any): Observable<any>{
    return this.httpClient.put(this.api+'/ShopFloorComformance/UpdateShopFloor',data)
  }
  
//   }
//   // Create
//   createTask(): Observable<any> {
//     let API_URL = `${this.apiUrl}/create-task`;
//     return this.http.post(API_URL, data)
//       .pipe(
//         catchError(this.error)
//       )
//   }

//   // Read
//   showTasks() {
//     return this.http.get(`${this.apiUrl}`);
//   }

//   // Update
//   updateTask(id, data): Observable<any> {
//     let API_URL = `${this.apiUrl}/update-task/${id}`;
//     return this.http.put(API_URL, data, { headers: this.headers }).pipe(
//       catchError(this.error)
//     )
//   }

//   // Delete
//   deleteTask(id): Observable<any> {
//     var API_URL = `${this.apiUrl}/delete-task/${id}`;
//     return this.http.delete(API_URL).pipe(
//       catchError(this.error)
//     )
//   }

//   // Handle Errors 
//   error(error: HttpErrorResponse) {
//     let errorMessage = '';
//     if (error.error instanceof ErrorEvent) {
//       errorMessage = error.error.message;
//     } else {
//       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
//     }
//     console.log(errorMessage);
//     return throwError(errorMessage);
//   }

}