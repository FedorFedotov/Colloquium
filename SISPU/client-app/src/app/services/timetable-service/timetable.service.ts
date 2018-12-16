
import { Injectable, EventEmitter } from '@angular/core';
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


export class TimetableService {

   fucURL = 'https://cors-anywhere.herokuapp.com/http://schedule.ispu.ru/API/API/Schedule/get_groups.json';
   groURL = 'https://cors-anywhere.herokuapp.com/http://schedule.ispu.ru/API/API/Schedule/get_groups?faculty_id=';
   timURL = 'https://cors-anywhere.herokuapp.com/http://schedule.ispu.ru/API/API/Schedule/get_groups?group_id=';
  public searchGrouptimetableEvent: EventEmitter<Grouptimetable[]> = new EventEmitter();
  public noMoreResultsFromServerEvent = new EventEmitter();
  public percentageEvent: EventEmitter<string> = new EventEmitter();

  loadedGrouptimetable: Grouptimetable[] = [];
  loadedFaculties: Faculty[]=[];
  loadedGroups: Group[]=[];
  
  FacultiesCounter: number=0;
  GroupsCounter: number=0;

  private search: string = '';


  constructor(private http: Http) {
   }

   resetSearch() {
    this.loadedGrouptimetable = [];
  }

  private extractData1(res: Response) {
    return res.json() as Facultiesjson;
  }

  private extractData2(res: Response) {
    return res.json() as Groupsjson;
  }

  private extractData3(res: Response) {
    return res.json() as Grouptimetable;
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


   getSearchResult(text: string, URL:string, id: string, flag: number): Observable<any> {
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

    if (flag == 1) {
      return this.http.get(URL+id, requestOptions)
      .map(this.extractData1)
      .catch(this.handleError);
    }

    if (flag == 2) {
      return this.http.get(URL+id, requestOptions)
      .map(this.extractData2)
      .catch(this.handleError);
    }

    if (flag == 3) {
      return this.http.get(URL+id, requestOptions)
      .map(this.extractData3)
      .catch(this.handleError);
    }

  }

  public searchResultsChanged(val: Grouptimetable[]) {

    this.searchGrouptimetableEvent.emit(val);

  }


   loadNext(): void {

    this.getSearchResult(this.search, this.fucURL, "", 1)
      .subscribe(r => {


        if (r.faculties!= undefined && r.faculties.length !== 0) 
        {
          this.loadedFaculties = r.faculties;
          this.percentageEvent.emit("Факультеты загружены");
          this.loadedFaculties.forEach(element => {

            this.getSearchResult(this.search, this.groURL, element.faculty_id.toString(), 2)
            .subscribe(rr => {
              if (rr.groups!= undefined && rr.groups.length !== 0) 
              {
                this.loadedGroups = this.loadedGroups.concat(rr.groups);
                this.FacultiesCounter++;

                          if (this.FacultiesCounter == this.loadedFaculties.length) 
                        {
                          this.percentageEvent.emit("Группы загружены");

                         // var citrus = this.loadedGroups.slice(0, 5);
                         this.loadedGroups.forEach(elementt => {   //citrus -> this.loadedGroups
                            this.getSearchResult(this.search, this.timURL, elementt.group_id.toString(), 3)
                            .subscribe(rrr => {                                     
                                this.GroupsCounter++;
                                

                                if (rrr.group_name != undefined)
                                {
                                  this.loadedGrouptimetable = this.loadedGrouptimetable.concat(rrr);
                                }
                                this.percentageEvent.emit("Загружено/Доступно "+this.loadedGrouptimetable.length+" расписаний из "+ this.loadedGroups.length);
                                if (this.GroupsCounter ==this.loadedGroups.length )  //this.loadedGroups.length
                                {
                                console.log(this.loadedGrouptimetable.length+"Расписаний прошли");
                                this.searchResultsChanged(this.loadedGrouptimetable);
                                }
                            
                            });
                      
                          });
                        }
              }
            });
      
          });
        }

      });

  }



}
