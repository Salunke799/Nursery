import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {
  dtOptions: any = {};
  empData = [];
  constructor() { }

  ngOnInit() {
    this.dtOptions = {
      responsive: true
    }
  }

}
