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
import { TeacherService } from '../../services/teacher-service/teacher.service';
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
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  grouptimetables: Grouptimetable[]=[];
  cleargrouptimetables: Grouptimetable[] =[];
  Loading: string = 'Список расписаний групп пуст';
  Info: string = '';
  Status: boolean = false;
  faculties: Faculty[];
  groups: Group[];
  safeteachers: Teacher[]=[];
  teachers: Teacher[]=[];
  source: boolean = false; // true = my server works

  subscription: Subscription;
  subscription1: Subscription;

  selectedGrouptimetable: Grouptimetable;
  isButtonHidden: boolean = true;

  constructor(private ref: ChangeDetectorRef, private GroupService: GroupService, private TeacherService: TeacherService, private FacultyService: FacultyService, private TimetableService: TimetableService, private UptimetableService: UptimetableService) { }


  ngOnInit() {

 
    this.TeacherService.GetAllTeachers().subscribe(
      (result) => {
          var a = result.json();
          if(a!=null && a.length!=0)
          { this.source = true;
            var gc = new Array<Teacher>();
            gc = [];
            gc = a;
            this.teachers = gc;
            this.safeteachers=gc;
            console.log(this.teachers);
           this.ref.detectChanges();

          }
          else{
          }
    }); 


  }

  Search (searchinput: string)
  {
          var gc = new Array<Teacher>();
            gc = [];
            gc = this.teachers;
            this.teachers = [];
            this.safeteachers.forEach(element=>
            {
             if ( element.teacher_name.includes(searchinput)) this.teachers.push(element);
            })
           this.ref.detectChanges();

  }


  

  ngOnDestroy() {
  }



  
  trackById(index, item: Teacher) {
    return item.teacher_name;
  }

}
