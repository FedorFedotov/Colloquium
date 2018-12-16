
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
  selector: 'app-timetables',
  templateUrl: './timetables.component.html',
  styleUrls: ['./timetables.component.css']
})
export class TimetablesComponent implements OnInit {

  grouptimetables: Grouptimetable[]=[];
  safegrouptimetables: Grouptimetable[]=[];
  cleargrouptimetables: Grouptimetable[] =[];
  Loading: string = 'Список расписаний групп пуст';
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


  UploadTimetables()
  {
    

    if( this.grouptimetables.length>0) 
    {
      this.grouptimetables.forEach(element => {
        var gt = new Grouptimetable();
        gt.group_name=element.group_name;
           element.days.forEach(elemen => {
            var da = new Day();
            da.weekday=elemen.weekday;
            elemen.lessons.forEach(eleme => {
              var le = new Lesson();
              le.subject = eleme.subject;
              le.type = eleme.type;
              le.time_start = eleme.time_start;
              le.time_end=eleme.time_end;
              le.parity=eleme.parity;
              le.date_start=eleme.date_start;
              le.date_end=eleme.date_end;
              le.dates=1; 
                    if(eleme.teachers.length!=0)
                    {
                      eleme.teachers.forEach(elem => {
                        var te = new Teacher();
                        te.teacher_name=elem.teacher_name;
                        le.teachers.push(te);
                    }); 
                    }  
                    else 
                    {
                        var te = new Teacher();
                        te.teacher_name="";
                        le.teachers.push(te);
                    }
  
                    if(eleme.auditories.length!=0)
                    {
                      eleme.auditories.forEach(ele => {
                        var au = new Auditory();
                        au.auditory_name=ele.auditory_name;
                        au.auditory_address=ele.auditory_address;
                        le.auditories.push(au);
                    });
                    }
                    else
                    {
                        var au = new Auditory();
                        au.auditory_name="";
                        au.auditory_address="";
                        le.auditories.push(au);
                    }
  
    
             da.lessons.push(le);
          });
  
          gt.days.push(da);
  
        });
  
        this.cleargrouptimetables.push(gt);
  
      });
  
      this.UptimetableService.UploadTimetables(this.cleargrouptimetables).subscribe(
        (result) => {
            var a = result.json();
            if(a!=null)
            {
              this.Info=a.ToString;
            }
            else{
            }
      });
  
      this.cleargrouptimetables =[];
    }
    

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
