import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './app-routing.guard';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './login/login.component';
import { Role } from './models/role';
import { SalesComponent } from './sales/sales.component';
import { AttendanceComponent } from './attendance/attendance.component';
import { PurchaseComponent } from './purchase/purchase.component';
import { FarmerComponent } from './farmer/farmer.component';
import { NurseryComponent } from './nursery/nursery.component';



const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', component: HomeComponent },
      { path: 'attendance', canActivate: [AuthGuard], component: AttendanceComponent },
      { path: 'purchase', canActivate: [AuthGuard], component: PurchaseComponent },
      { path: 'sales', component: SalesComponent },
      { path: 'farmer', component: FarmerComponent },
      { path: 'nursery', component: NurseryComponent },


      { path: 'login', component: LoginComponent },
    ]
  },
  {
    path: 'admin',
    canLoad: [AuthGuard],
    canActivate: [AuthGuard],
    data: {
      roles: [
        Role.Admin,
      ]
    },
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
  },
  //{
  //  path: '**',
  //  component: '' ,
  //}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [
    AuthGuard,
    AuthService
  ]
})
export class AppRoutingModule { }
