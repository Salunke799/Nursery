import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CalendarModule } from 'primeng/calendar';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { UserRoleDirective } from './directives/user-role.directive';
import { UserDirective } from './directives/user.directive';
import { AuthService } from './services/auth.service';
import { DialogModule } from 'primeng/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { SalesComponent } from './sales/sales.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { DataTablesModule } from 'angular-datatables';
import { FarmerComponent } from './farmer/farmer.component';
import { AddEditFarmerComponent } from './farmer/add-edit-farmer/add-edit-farmer.component';
import { NurseryComponent } from './nursery/nursery.component';
import { AddEditNurseryComponent } from './nursery/add-edit-nursery/add-edit-nursery.component';
import { AddSalesComponent } from './sales/add-sales/add-sales.component';
import { HttpClientModule } from '@angular/common/http';
import { AddPurchaseComponent } from './purchase/add-purchase/add-purchase.component';
import { AddAttendanceComponent } from './attendance/add-attendance/add-attendance.component';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,  
    LoginComponent,
    UserDirective,
    UserRoleDirective,   
    SalesComponent,  AttendanceComponent,  PurchaseComponent,
    FarmerComponent, AddEditFarmerComponent, NurseryComponent,
    AddEditNurseryComponent, AddSalesComponent, AddPurchaseComponent, AddAttendanceComponent, NavMenuComponent
  ],
  imports: [
    BrowserModule, CalendarModule,
    AppRoutingModule, DialogModule, BrowserAnimationsModule, FormsModule, DataTablesModule, HttpClientModule,
    ReactiveFormsModule, 
  ],
  exports: [
    UserDirective,
    UserRoleDirective
  ],
  providers: [AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
