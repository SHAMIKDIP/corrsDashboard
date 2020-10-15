import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddNewUserComponent } from './add-new-user/add-new-user.component'
import { DashboardComponent } from './dashboard/dashboard.component'
import { ResonCornerComponent } from './reson-corner/reson-corner.component'

const routes: Routes = [
  {path:'adduser', component:AddNewUserComponent},
  {path:'addreason', component:DashboardComponent},
  {path:'reasoncorner', component:ResonCornerComponent},
  {path:'**', pathMatch:'full', redirectTo:'adduser'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
