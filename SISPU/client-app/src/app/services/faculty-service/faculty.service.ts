import { Injectable, EventEmitter } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Faculty } from '../../classes/faculty'
import { CustomQueryEncoderHelper } from '../../helpers/custom-query-encode.helper'
import { Facultiesjson } from '../../classes/facultiesjson'
import { UserTokenStorage } from '../../classes/user-token-storage';
import { HttpClient } from '@angular/common/http';

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch'


@Injectable({
  providedIn: 'root'
})


export class FacultyService {

 
  baseUrl = 'https://cors-anywhere.herokuapp.com/http://schedule.ispu.ru/API/API/Schedule/get_groups.json'; 
  public searchEvent: EventEmitter<Faculty[]> = new EventEmitter();
  public noMoreResultsFromServerEvent = new EventEmitter();

  loadedFaculties: Faculty[] = [];
  private search: string = '';

  constructor(private http: Http) {
   }

   resetSearch() {
    this.loadedFaculties = [];
  }


  private extractData(res: Response) {
    console.log(res.json() as Facultiesjson);
    return res.json() as Facultiesjson;
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


   getSearchResult(text: string): Observable<Facultiesjson> {
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

    return this.http.get(this.baseUrl, requestOptions)
      .map(this.extractData)
      .catch(this.handleError);
  }

  public searchResultsChanged(val: Faculty[]) {
   // if (val!=undefined && this.loadedFaculties.length === 0) this.loadedFaculties = val;

  //  if (pages != undefined) {
    //  this.totalPageNumber = pages;
   // }

    this.searchEvent.emit(val);
   // if (this.pageNumber > this.totalPageNumber || this.totalPageNumber === 1) {
    //  this.noMoreResultsFromServerEvent.emit();
   // }
  }


   loadNext(): void {
    this.getSearchResult(this.search)
      .subscribe(r => {
        if (r.faculties!= undefined && r.faculties.length !== 0) 
        {
          this.loadedFaculties = this.loadedFaculties.concat(r.faculties);
          this.searchResultsChanged(this.loadedFaculties);
          this.loadedFaculties=[];
        }
      });
  }



}
