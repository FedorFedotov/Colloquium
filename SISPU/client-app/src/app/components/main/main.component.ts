import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { RouterModule, Routes, RouterLinkActive } from '@angular/router';

import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { Subscription } from 'rxjs/Subscription';

import { DOCUMENT } from "@angular/platform-browser";
import { HttpModule, Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';


import 'rxjs/add/operator/share';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})

export class MainComponent implements OnInit, OnDestroy {



  constructor(private router: Router) {
  }

  ngOnInit() {

  }

  ngOnDestroy() {

  }

}
