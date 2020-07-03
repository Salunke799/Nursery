import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { HttpClient } from '@angular/common/http';
import { Role } from '../models/role';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  Role = Role;
  displayModal: boolean;
  title = 'Login';
  email = '';
  password = '';
  credentials = '';
  basic = '';
  constructor(private router: Router,
    private authService: AuthService,
    private http: HttpClient
  ) { }

  ngOnInit() {
  }

  showModalDialog() {
    this.displayModal = true;
  }
  createAuthorizationHeader(headers: Headers, basic) {
    headers.append('Authorization', basic);
  }
  login(role: Role) {
    this.authService.login(role);
    this.router.navigate(['/']);
    this.displayModal = false;

    //this.email = (<HTMLInputElement>document.getElementById("email")).value;
    //this.password = (<HTMLInputElement>document.getElementById("password")).value;
    //this.credentials = this.email + ":" + this.password;
    //this.basic = "Basic " + btoa(this.credentials);
    //console.log(this.basic);
    //let headers = new Headers();
    //headers.append('Content-Type', 'application/json');
    //headers.append('Authorization', this.basic);
    //console.log(headers);
    //return this.http.post('http://localhost:8000/api/v1/authenticate', role)
    //  .subscribe(
    //    res => {
    //      console.log(res);
    //    },
    //    err => {
    //      console.log(err.message);
    //    }
    //  )
  }

  

  logout() {
    this.authService.logout();
  }
}
