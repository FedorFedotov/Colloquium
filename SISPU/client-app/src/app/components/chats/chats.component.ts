
import { Injectable, Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { DOCUMENT } from "@angular/platform-browser";
import { HttpModule, Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { GroupService } from '../../services/group-service/group.service';
import { Group } from '../../classes/group';
import { FacultyService } from '../../services/faculty-service/faculty.service';
import { Faculty } from '../../classes/faculty';
import { CustomQueryEncoderHelper } from '../../helpers/custom-query-encode.helper'
import { Facultiesjson } from '../../classes/facultiesjson'
import { UserTokenStorage } from '../../classes/user-token-storage';
import { HttpClient } from '@angular/common/http';
import { TimetableService } from '../../services/timetable-service/timetable.service';
import { Grouptimetable } from '../../classes/grouptimetable'
import { UptimetableService } from '../../services/uptimetable-service/uptimetable.service';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';

import { Auditory } from '../../classes/auditory';
import { Teacher } from '../../classes/teacher';
import { Lesson } from '../../classes/lesson';
import { Day } from '../../classes/day';

import 'rxjs/add/operator/share';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch';


@Component({
  selector: 'app-chats',
  templateUrl: './chats.component.html',
  styleUrls: ['./chats.component.css']
})
export class ChatsComponent implements OnInit {

  grouptimetables: Grouptimetable[]=[];
  safegrouptimetables: Grouptimetable[]=[];
  cleargrouptimetables: Grouptimetable[] =[];
  Loading: string = 'Список вакансий пуст';
  Info: string = '';
  Status: boolean = false;
  faculties: Faculty[];
  groups: Group[];
  source: boolean = false; // true = my server works

  subscription: Subscription;
  subscription1: Subscription;

  selectedGrouptimetable: Grouptimetable;
  isButtonHidden: boolean = true;

  constructor(private ref: ChangeDetectorRef,private GroupService: GroupService, private FacultyService: FacultyService, private TimetableService: TimetableService, private UptimetableService: UptimetableService) { }


  ngOnInit() {

 
    this.UptimetableService.getAllGroupTimetables().subscribe(
      (result) => {
          var a = result.json();
          if(a!=null && a.length!=0)
          { this.source = true;
            var gt = new Array<Grouptimetable>();
            gt = [];
            gt = a;
            this.grouptimetables = gt;
            this.safegrouptimetables = gt;
          }
          else{
          }
    });


  


    this.subscription = this.TimetableService.searchGrouptimetableEvent.subscribe((newResults) => {
      this.grouptimetables =[]
      this.grouptimetables = newResults;
    });

    this.subscription1 = this.TimetableService.percentageEvent.subscribe((res) => {
      this.Status=true;
     this.Info=res;
    });


  }

  Search (searchinput: string)
  {
          var gc = new Array<Grouptimetable>();
            gc = [];
            gc = this.grouptimetables;
            this.grouptimetables = [];
            this.safegrouptimetables.forEach(element=>
            {
             if ( element.group_name.includes(searchinput)) this.grouptimetables.push(element);
            })
           this.ref.detectChanges();

  }


  DownloadTimetables() {
    this.TimetableService.loadNext();
    this.Loading='Идет загрузка, подождите';
  }



  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.subscription1.unsubscribe();
  }

  onSelect(grouptimetable: Grouptimetable): void {
    this.selectedGrouptimetable = grouptimetable;
  }

  
  trackById(index, item: Grouptimetable) {
    return item.group_name;
  }

}
