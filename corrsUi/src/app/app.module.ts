import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import {MatTableModule} from '@angular/material/table';
import {DataTablesModule} from 'angular-datatables';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddNewUserComponent } from './add-new-user/add-new-user.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { ResonCornerComponent } from './reson-corner/reson-corner.component';
import { CommonModal } from './modal/Modal'
import { Spinner } from './spinner/Spinner'

@NgModule({
  declarations: [
    AppComponent,
    AddNewUserComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    ResonCornerComponent,
    CommonModal,
    Spinner
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    DataTablesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
