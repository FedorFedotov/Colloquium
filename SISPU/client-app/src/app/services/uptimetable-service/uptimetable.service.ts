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
export class UptimetableService 
{
    baseUrl="/api/grouptimetable";
    private headers: Headers;
    public uploadEvent: EventEmitter<any> = new EventEmitter();

    constructor(private http: Http) {
        this.http = http;
        this.headers = new Headers();
        this.headers.append('Content-Type', 'application/json');
        //this.headers.append('Authorization', 'Bearer ' + UserTokenStorage.getInstance().getUserToken());
   }

   //---------------------------------------------Http services----------------------------------
  getGrouptimetable(group_name: string)  
  {
    return this.http.get(this.baseUrl + "/" + group_name, {headers: this.headers});
  }

  UploadTimetables(grouptimetables: Grouptimetable[])
  {
    return this.http.post(this.baseUrl, JSON.stringify(grouptimetables) ,{headers: this.headers});
  }

  getAllGroupTimetables()  
  {
    return this.http.get(this.baseUrl , {headers: this.headers});
  }

//  updatePosition(position: Position)
 // {
 //   return this.http.put(this.baseUrl, JSON.stringify(position) ,{headers: this.headers});
 // }

  deleteGroup(group_name: string)
  {
    return this.http.delete(this.baseUrl + "/" + group_name, {headers: this.headers});
 }
 

//  delegatePosition(pos)
 // {
  //  this.DelegatePosition.emit(pos);
 // }

 //--------------------------------------------Http additional services---------------------------------
 // getAllTeams(){
  //  return this.http.get(this.baseUrl + "/teams",{headers: this.headers});
 // }
 // getAllLevels(){
  //  return this.http.get(this.baseUrl + "/english",{headers: this.headers});
 // }
 // searchRequirements(str: string){
 //   return this.http.get(this.baseUrl + "/requirements/" + str,{headers: this.headers});
  //}

  //--------------------------------------------Internal services----------------------------------------

}

