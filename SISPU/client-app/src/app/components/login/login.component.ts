import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  login: boolean = true;
  register: boolean = false;
  forget: boolean = false;
  constructor() { }

  ngOnInit() {
  }

  Start() {
    this.login = true;
    this.register = false;
    this.forget = false;
  }

  
  Register() {
    this.login = false;
    this.register = true;
    this.forget = false;
  }

  Forget() {
    this.login = false;
    this.forget = true;
    this.register = false;
  }

}


