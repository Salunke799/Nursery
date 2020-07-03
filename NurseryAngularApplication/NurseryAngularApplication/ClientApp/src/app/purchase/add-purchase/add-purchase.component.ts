import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'add-purchase',
  templateUrl: './add-purchase.component.html',
  styleUrls: ['./add-purchase.component.css']
})
export class AddPurchaseComponent implements OnInit {

  displayModal: boolean;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  showModalDialog() {
    this.displayModal = true;
  }  
  close() {
    this.displayModal = false;
  }
}
