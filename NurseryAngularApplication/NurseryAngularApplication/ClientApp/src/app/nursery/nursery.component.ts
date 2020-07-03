import { Component, OnInit, ViewChild } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../services/data.service';


@Component({
  selector: 'nursery',
  templateUrl: './nursery.component.html',
  styleUrls: ['./nursery.component.css']
})
export class NurseryComponent implements OnInit {
  dtOptions: any = {};
  nursery: any;
  state: any; 

  constructor(
    private dataService: DataService) {

  }
  loading: boolean;
  ngOnInit() {
    this.dtOptions = {          
      responsive: true      
    }
    this.getData();
  }
  
  deleteNursery(id: number) {
    this.dataService.deleteNursey(id).subscribe(() => {

    });
  
  }
  
  getData() {
    this.dataService.getNurseyData().subscribe(
      data => {
        this.nursery = data;
      }
    );
  }  
  getState() {
    this.dataService.getState().subscribe(
      data => {
        this.state = data;
      }
    );
  }  
}
