import { Component, OnInit } from '@angular/core';
import { DataService } from '../services/data.service';

@Component({
  selector: 'purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
  nursery: any;
  constructor(
    private dataService: DataService
  ) { }

  ngOnInit() {
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
