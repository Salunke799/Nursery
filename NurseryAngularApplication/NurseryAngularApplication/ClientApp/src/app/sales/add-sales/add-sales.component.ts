import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'add-sales',
  templateUrl: './add-sales.component.html',
  styleUrls: ['./add-sales.component.css']
})
export class AddSalesComponent implements OnInit {

  displayModal: boolean;
  constructor(private router: Router) { }
  quaValue: any;
  costValue: any;
  totalValue: any;

  productDetail = [
    { name: 'abc', que: '5,000', cost: '10', total: '50,000' },
    { name: 'abc', que: '5,000', cost: '10', total: '50,000' },
    { name: 'abc', que: '5,000', cost: '10', total: '50,000' },
    { name: 'abc', que: '5,000', cost: '10', total: '50,000' },
  ]

  ngOnInit() {
  }

  showModalDialog() {
    this.displayModal = true;
  }
  onInputChange(event: any) {
    debugger
    alert(event.target.value);
}
  close() {
    this.displayModal = false;
  }
}
