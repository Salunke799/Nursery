import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../../services/data.service';
import { Employee } from '../../services/service-file/employee';

@Component({
  selector: 'add-edit-employee',
  templateUrl: './add-edit-employee.component.html',
  styleUrls: ['./add-edit-employee.component.css']
})
export class AddEditEmployeeComponent implements OnInit {
  nursery: any;
  displayModal: boolean;
  emp: Employee = new Employee();
  active = false;
  state = [
    { id: '1', name: "Andhra Pradesh", },
    { id: '2', name: "Arunachal Pradesh" },
    { id: '3', name: "Assam" },
    { id: '4', name: "Bihar" },
    { id: '5', name: "Chhattisgarh" },
    { id: '6', name: "Goa" },
    { id: '7', name: "Gujarat" },
    { id: '8', name: "Haryana" },
    { id: '9', name: "Himachal Pradesh" },
    { id: '10', name: "Jammu and Kashmir" },
    { id: '11', name: "Jharkhand" },
    { id: '12', name: "Karnataka" },
    { id: '13', name: "Kerala" },
    { id: '14', name: "Madhya Pradesh" },
    { id: '15', name: "Maharashtra" },
    { id: '16', name: "Manipur" },
    { id: '17', name: "Meghalaya" },
    { id: '18', name: "Mizoram" },
    { id: '19', name: "Nagaland" },
    { id: '20', name: "Odisha" },
    { id: '21', name: "Punjab" },
    { id: '22', name: "Rajasthan" },
    { id: '23', name: "Sikkim" },
    { id: '24', name: "Tamil Nadu" },
    { id: '25', name: "Telangana" },
    { id: '26', name: "Tripura" },
    { id: '27', name: "Uttarakhand" },
    { id: '28', name: "Uttar Pradesh" },
    { id: '29', name: "West Bengal" },
    { id: '30', name: "Andaman and Nicobar Islands" },
    { id: '31', name: "Chandigarh" },
    { id: '32', name: "Dadra and Nagar Haveli" },
    { id: '33', name: "Daman and Diu" },
    { id: '34', name: "Delhi" },
    { id: '35', name: "Lakshadweep" },
    { id: '36', name: "Puducherry" }]
  educationDegree = [
    { id: '', name: 'Primary Education' },
    { id: '', name: 'Secondary Education' },
    { id: '', name: 'Bachelor Degree' },
    { id: '', name: 'Master  Degree' }
  ]
  constructor(private router: Router,
    private dataService: DataService
  ) { }

  
  
  ngOnInit() {
    this.getNurseryData();
    this.active = true;
  }
  
  showModalDialog(id?: number) {
    if (!id) {
      this.displayModal = true;
      this.active = true;
    }
    else {
      this.dataService.editNurseyGetData(id).subscribe(data => {
        let a = data;
        //this.nurseys = data;
        this.displayModal = true;
        this.active = true;
      });
    }
  }
  getNurseryData() {
    this.dataService.getNurseyData().subscribe(
      data => {
        this.nursery = data;
      }
    );    
  }
  addEmployee() {
    debugger
    this.dataService.addEmployee(this.emp).subscribe(res => {

    });
    this.active = false;
    this.displayModal = false;
  }
  close() {
    this.displayModal = false;
    this.active = false;
  }
}
