import { Injectable, EventEmitter } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Group } from '../../classes/group'
import { CustomQueryEncoderHelper } from '../../helpers/custom-query-encode.helper'
import { Groupsjson } from '../../classes/groupsjson'
import { UserTokenStorage } from '../../classes/user-token-storage';
import { HttpClient } from '@angular/common/http';
import { Faculty } from '../../classes/faculty'
import { Facultyjson } from '../../classes/facultyjson'

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch'


@Injectable({
  providedIn: 'root'
})


export class GroupService {

 
  baseUrl = 'https://cors-anywhere.herokuapp.com/http://schedule.ispu.ru/API/API/Schedule/get_groups?faculty_id='; 
  public searchGroupEvent: EventEmitter<Group[]> = new EventEmitter();
  public searchGroupEvent2: EventEmitter<Facultyjson[]> = new EventEmitter();
  public noMoreResultsFromServerEvent = new EventEmitter();

  loadedGroups: Group[] = [];
  loadedjsonfaculties: Facultyjson[] = [];
  
  private search: string = '';

  constructor(private http: Http) {
   }

   resetSearch() {
    this.loadedGroups = [];
  }


  private extractData(res: Response) {
    return res.json() as Groupsjson;
  }

  private handleError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }


   getSearchResult(text: string, id: string): Observable<Groupsjson> {
    if (this.search !== text) {
      this.search = text;
      this.resetSearch();
    }
    const params: URLSearchParams = new URLSearchParams('', new CustomQueryEncoderHelper());
    params.set('text', text);
    const requestOptions: RequestOptions = new RequestOptions();
    requestOptions.params = params;
    requestOptions.headers = new Headers();
    requestOptions.headers.append('Content-Type', 'application/json');
    //requestOptions.headers.append('Authorization', 'Bearer ' + UserTokenStorage.getInstance().getUserToken());

    return this.http.get(this.baseUrl+id, requestOptions)
      .map(this.extractData)
      .catch(this.handleError);
  }

  public searchResultsChanged(val: Group[]) {
   // if (val!=undefined && this.loadedFaculties.length === 0) this.loadedFaculties = val;

  //  if (pages != undefined) {
    //  this.totalPageNumber = pages;
   // }

    this.searchGroupEvent.emit(val);
   // if (this.pageNumber > this.totalPageNumber || this.totalPageNumber === 1) {
    //  this.noMoreResultsFromServerEvent.emit();
   // }
  }

  public searchResultsChanged2(val: Facultyjson[]) {
     this.searchGroupEvent2.emit(val);
   }


   loadNext(faculties: Faculty[]): void {
     
    faculties.forEach(element => {

      this.getSearchResult(this.search, element.faculty_id.toString())
      .subscribe(r => {
        if (r.groups!= undefined && r.groups.length !== 0) 
        {
          this.loadedGroups = this.loadedGroups.concat(r.groups);
          
          this.searchResultsChanged(this.loadedGroups);
        }
      });

    });
  }

  loadNext2(faculties: Faculty[]): void {
     
    faculties.forEach(element => {
  
      
      this.getSearchResult(this.search, element.faculty_id.toString())
      .subscribe(r => {
        if (r.groups!= undefined && r.groups.length !== 0) 
        {
          var fj = new Facultyjson();
          fj.faculty_id=element.faculty_id;
          fj.faculty_name=element.faculty_name;
          fj.groups=r.groups;
          this.loadedjsonfaculties.push(fj);          
          this.searchResultsChanged2(this.loadedjsonfaculties);
        }
      });

    });
  }



}
