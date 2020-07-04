import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  dtOptions: any = {};
  nursery: any;
  constructor(
    private dataService: DataService
  ) { }
  empData: any;
  loading: boolean;
  ngOnInit() {
    this.dtOptions = {          
      responsive: true      
    }
    this.getEmpData();
    //this.getNurseryData();
  }
  getEmpData() {
    this.dataService.getEmpData().subscribe(
      data => {
        this.empData = data;
      }
    );
  }
  deleteEmp(id: number) {
    this.dataService.deleteNursey(id).subscribe(() => {

    });
  }
  editEmp(id: number) {
    this.dataService.editEmpGetData(id).subscribe(() => {

    });
  }
  selectNursery(id) {
    debugger
    this.dataService.getEmpId(id).subscribe(
      data => {
        this.empData = data;
      }
    );
  }
  getNurseryData() {
    this.dataService.getNurseyData().subscribe(
      data => {
        this.nursery = data;
      }
    );
  }  
}
