import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'corrs';
  constructor(public httpClient: HttpClient){}
  sendGetRequest(){
    this.httpClient.get('https://localhost:44377/Corrsplants/getcategories').subscribe((res)=>{
        console.log(res);
    });
}
}
