import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'farmer',
  templateUrl: './farmer.component.html',
  styleUrls: ['./farmer.component.css']
})
export class FarmerComponent implements OnInit {
  dtOptions: any = {};
  nursery: any;
  constructor(
    private dataService: DataService
  ) { }
  farmerData: any;
  loading: boolean;
  ngOnInit() {
    this.dtOptions = {     
      // Use this attribute to enable the responsive extension
      responsive: true      
    }
    this.getFarmerData();
    this.getNurseryData();
  }
  getFarmerData() {
    this.dataService.getFarmer().subscribe(
      data => {
        this.farmerData = data;
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
  selectNursery(id) {    
    this.dataService.getFarmerId(id).subscribe(
      data => {
        this.nursery = data;
      }
    );
  }
  delFarmer(id: number) {
    this.dataService.delFarmerId(id).subscribe(data => {

    });
  }
  editFarmer(id: number) {
    this.dataService.editFarmerGetData(id).subscribe(data => {

    });
  }
}
