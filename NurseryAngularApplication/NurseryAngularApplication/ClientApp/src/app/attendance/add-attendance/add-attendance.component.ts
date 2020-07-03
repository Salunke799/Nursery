import { Component, OnInit } from '@angular/core';
import { Router, Data } from '@angular/router';


@Component({
  selector: 'add-attendance',
  templateUrl: './add-attendance.component.html',
  styleUrls: ['./add-attendance.component.css']
})
export class AddAttendanceComponent implements OnInit {

  displayModal: boolean;
  constructor(private router: Router) { }
  todayDate: Data;
  ngOnInit() {
 
  }
  showModalDialog() {
    this.displayModal = true;
    alert(this.todayDate)
  }
  cal() {
    debugger
    let d = new Date();
    let n = d.getMonth();
    let a = d.getDay();
    let b = d.getFullYear();
    let c = d.getMonth;
    let e = d.getDay();
    let f = d.getDay();
    alert(n);
    alert(a);
    alert(b);
    alert(c);
    alert(e)
  }

  close() {
    this.displayModal = false;
  }
}
