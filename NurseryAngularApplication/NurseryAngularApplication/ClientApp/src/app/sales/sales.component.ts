import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {

  dtOptions: any = {};
  nursery: any;
  constructor(
    private dataService: DataService
  ) { }
  salesData = [];

  ngOnInit() {
    this.dtOptions = {
      responsive: true
    }
    this.getNurseryData();
  }
  getNurseryData() {
    this.dataService.getNurseyData().subscribe(
      data => {
        this.nursery = data;
      }
    );
  }
  selectNursery(value) {
    alert(value);
  }
}
