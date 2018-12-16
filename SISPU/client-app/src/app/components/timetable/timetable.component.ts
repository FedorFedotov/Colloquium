
import { Injectable, Inject, Component, Input, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { CompleterService, CompleterData } from 'ng2-completer';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { Grouptimetable } from '../../classes/grouptimetable'

import { Teacher} from '../../classes/teacher';
import { Auditory} from '../../classes/auditory';
import { Lesson} from '../../classes/lesson';
import { Day} from '../../classes/day';
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-timetable',
  templateUrl: './timetable.component.html',
  styleUrls: ['./timetable.component.css']
})
export class TimetableComponent implements OnInit 
{
  @Input() grouptimetable: Grouptimetable;
  @Input() source: boolean;
 // @Output() timetableDeleted = new EventEmitter();
  edit:boolean = false;
  edit2:boolean = false;
  time: Date = new Date(); 
  pparity: number = 1; 
  pday: number = 0;

  constructor(private ref: ChangeDetectorRef) {
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

  Edit()
  {
    if(this.edit==false) this.edit=true;
    else this.edit=false;
    

    this.ref.detectChanges();
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
