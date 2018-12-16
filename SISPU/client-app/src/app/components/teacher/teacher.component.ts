import { Injectable, Inject, Component, Input, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { CompleterService, CompleterData } from 'ng2-completer';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { Grouptimetable } from '../../classes/grouptimetable'
import { TeacherService } from '../../services/teacher-service/teacher.service';

import { Teacher} from '../../classes/teacher';
import { Auditory} from '../../classes/auditory';
import { Lesson} from '../../classes/lesson';
import { Day} from '../../classes/day';
import { Group } from '../../classes/group';

@Component({
  selector: 'app-teacher',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.css']
})
export class TeacherComponent implements OnInit 
{
  @Input() teacher: Teacher;
  @Input() source: boolean;
 // @Output() timetableDeleted = new EventEmitter();
  edit:boolean = false;
  timetables:Grouptimetable[]=[];
  timetable:Grouptimetable = new Grouptimetable();
  edit2:boolean = false;
  time: Date = new Date(); 
  pparity: number = 1; 
  pday: number = 0;
 
  constructor(private ref: ChangeDetectorRef, private TeacherService: TeacherService) {

   }

  ngOnInit() {
    if ( this.time.getMonth()<8)
    {
      var time2 = new Date(this.time.getFullYear()-1, 8, 1);
      var day = time2.getUTCDay();
    }
    else 
    {
      var time2 = new Date(this.time.getFullYear(), 8, 1);
      var day = time2.getUTCDay();
    }

      var today = new Date(this.time.getFullYear(), this.time.getMonth(),this.time.getDate()); 
      var chet: boolean;
      if (day==6) 
      {
        time2.setDate(time2.getDate()+2);
      }
        do
        {
          time2.setDate(time2.getDate()+1);
        }
        while(time2.getUTCDay()!=0)
        chet = true;

        do
        {
          time2.setDate(time2.getDate()+7);
          if (chet == true) chet = false;
          else chet = true;
        }
        while((time2!=today)&&(time2<today))

        if (time2==today) 
        {
          if (chet=true) this.pparity=2;
          else this.pparity=1;

          this.pday = today.getDay();

          this.ref.detectChanges();
        }
        else
        {
          if (chet=true) this.pparity=1;
          else this.pparity=2;

          this.pday = today.getDay();

          this.ref.detectChanges();
        }


  }

  Check()
  {

    if(this.edit==false) this.edit=true;
    else this.edit=false;
    

    this.ref.detectChanges();

    this.timetable = new Grouptimetable();
    this.TeacherService.GetGroupTimetable(this.teacher.teacher_name).subscribe(
      (result) => {
          var a = result.json();
          if(a!=null && a.length!=0)
          { 
            var gc = new Array<Grouptimetable>();
            gc = [];
            gc = a;
            this.timetables = gc;
 
            this.timetable.group_name = this.teacher.teacher_name;
            var dayss:Day[] = [];
            this.timetable.days = dayss;

            this.timetables.forEach(element => {
              element.days.forEach(elemen => {
                elemen.lessons.forEach(eleme => {
                  eleme.teachers.forEach(elem => {
                    if ( elem.teacher_name == this.teacher.teacher_name)
                    {
                      var lesson = new Lesson();
                      lesson.subject = eleme.subject;
                      lesson.time_start = eleme.time_start;
                      lesson.time_end = eleme.time_end;
                      lesson.parity = eleme.parity;
                      lesson.type = eleme.type;
                      lesson.dates=0;
                    lesson.date_start = element.group_name;
                      var auditories:Auditory[] = [];
                      auditories = eleme.auditories;
                      lesson.auditories = auditories;
                    lesson.date_end = elemen.weekday.toString();

                    if (this.timetable.days.find(v=> v.weekday === Number(lesson.date_end) && v.lessons[0].parity===lesson.parity)!=undefined )
                    {

                        this.timetable.days.find(v=> v.weekday === Number(lesson.date_end)&& v.lessons[0].parity===lesson.parity).lessons.push(lesson);

                    }
                    else 
                    {

                       var day = new Day();
                       day.weekday = Number(lesson.date_end);
                       var lessons:Lesson[] = [];
                       day.lessons = lessons;
                       day.lessons.push(lesson);
                       this.timetable.days.push(day);
                    }
                    }
           
                  });
           
                });
           
               });
        
            }); 


            var timetable2:Grouptimetable = new Grouptimetable();
            timetable2.group_name= this.timetable.group_name;
            for (var ii = 0; ii < 2; ii++)
            for (var i = 0; i < 6; i++)
            {
              var day1 = new Day();
              day1.weekday=i+1;
              timetable2.days.push(day1);
            }
            
            this.timetable.days.forEach(element => {
             if (element.lessons[0].parity==2)
             timetable2.days[element.weekday-1].lessons =element.lessons;
             else
             timetable2.days[element.weekday+5].lessons =element.lessons;

            });
            this.timetable = timetable2;
            this.ref.detectChanges();         
          }
          else{
          }
    }); 

  }


  Edit2()
  {

    if(this.edit2==false) this.edit2=true;
    else this.edit2=false;
    if(this.edit==false) this.edit=true;
    else this.edit=false;
    this.ref.detectChanges();
  }

}
