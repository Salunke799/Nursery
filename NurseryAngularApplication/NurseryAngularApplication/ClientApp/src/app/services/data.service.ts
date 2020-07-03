import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry,catchError, map } from 'rxjs/operators';
import { NurseryDto } from './service-file/nursery';
import { Farmer } from './service-file/farmer';
import { Employee } from './service-file/employee';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private baseurl  = "http://localhost:22742/api";
  private REST_API_SERVER = "http://localhost:22742";

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(
    private httpClient: HttpClient
  ) {

  }   
  addNursey1(nursery): Observable<NurseryDto> {
    debugger
    return this.httpClient.post<NurseryDto>(this.baseurl + '/Nursery/AddNursery', { body: JSON.stringify(nursery) });
  }
  addNursey(nursery) {
    debugger
    return this.httpClient.post<NurseryDto>(this.baseurl + '/Nursery/AddNursery', { body: JSON.stringify(nursery) });
  }
  getNurseyData() {
    return this.httpClient.get(this.baseurl + "/Nursery/GetAllNursery");
  }
  editNurseyGetData(id) {
    debugger
    return this.httpClient.get(this.baseurl + "/Nursery/GetEditNursery?Id=" + id);
  }
  deleteNursey(id) {
    return this.httpClient.delete(this.baseurl + "/Nursery/DeleteNursery?NursaryId="  +id);
  }
  editNursey(id) {
    return this.httpClient.get(this.baseurl + "/Nursery/UpdatePost?NursaryId="  +id);
  }
  deleteNursey1(id: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.httpClient.delete<number>(this.baseurl + "/Nursery/DeleteNursery?NursaryId=" + id,
      httpOptions);
  } 
  getState() { 
    return this.httpClient.get(this.baseurl + '/State/GetAllState');
  }
  getEmpData() {
    return this.httpClient.get(this.baseurl + "/Employee/GetAllEmployee");
  }
  addEmployee(emp) {
    debugger
    return this.httpClient.post<Employee>(this.baseurl + '/Employee/AddEmployee', { body: JSON.stringify(emp) });
  }
  delEmpId(id) {
    return this.httpClient.get(this.baseurl + "/Employee/DeleteEmployee?employeeId"+ id);
  }
  editEmpGetData(id) {
    debugger
    return this.httpClient.get(this.baseurl + "/Employee/GetEditEmployee?Id=" + id);
  }
  getFarmer() {    
    return this.httpClient.get(this.baseurl + "/Farmer/GetAllFarmer");
  }
  addFarmer(farmer) {
    return this.httpClient.post<Farmer>(this.baseurl + '/Farmer/AddFarmer', { body: JSON.stringify(farmer) });
  }
  getEmpId(id) {
    return this.httpClient.get(this.baseurl + "/Employee/GetAllEmployee?nurseryId=" + id);
  } 
  delFarmerId(id) {
    return this.httpClient.get(this.baseurl + "/Nursery/DeleteNursery?NursaryId=" + id);
  }
  editFarmerGetData(id) {
    debugger
    return this.httpClient.get(this.baseurl + "/Farmer/GetEditFarmer?Id=" + id);
  }
  getFarmerId(id) {
    return this.httpClient.get(this.baseurl + "/Farmer/GetAllFarmer?nurseryId=" + id);
  }
}
