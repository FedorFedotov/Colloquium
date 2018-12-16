import { Injectable, Inject, Component, Input, Output, EventEmitter } from '@angular/core';
import 'rxjs/add/operator/toPromise';

import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Group } from '../../classes/group'
import { CustomQueryEncoderHelper } from '../../helpers/custom-query-encode.helper'
import { Groupsjson } from '../../classes/groupsjson'
import { UserTokenStorage } from '../../classes/user-token-storage';
import { HttpClient } from '@angular/common/http';
import { Faculty } from '../../classes/faculty'
import { Facultiesjson } from '../../classes/facultiesjson'
import { Grouptimetable } from '../../classes/grouptimetable'

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch'

@Injectable({
  providedIn: 'root'
})
export class UpfacultyService {

  baseUrl="/api/faculty";
  private headers: Headers;
  public uploadEvent: EventEmitter<any> = new EventEmitter();

  constructor(private http: Http) {
      this.http = http;
      this.headers = new Headers();
      this.headers.append('Content-Type', 'application/json');
      //this.headers.append('Authorization', 'Bearer ' + UserTokenStorage.getInstance().getUserToken());
 }


  UploadFaculties(faculties: Faculty[])
  {
    return this.http.post(this.baseUrl, JSON.stringify(faculties) ,{headers: this.headers});
  }

  getAllFaculties()  
  {
    return this.http.get(this.baseUrl , {headers: this.headers});
  }

}
