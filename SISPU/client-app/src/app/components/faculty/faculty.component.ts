import { Injectable, Inject, Component, Input, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Faculty } from '../../classes/faculty'
import { CompleterService, CompleterData } from 'ng2-completer';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { Facultyjson } from '../../classes/facultyjson'
import { UptimetableService } from '../../services/uptimetable-service/uptimetable.service';


@Component({
  selector: 'app-faculty',
  templateUrl: './faculty.component.html',
  styleUrls: ['./faculty.component.css']
})
export class FacultyComponent implements OnInit 
{
  @Input() jsonfaculty: Facultyjson;
  @Input() source: boolean;
  @Output() jsonfacultyDeleted = new EventEmitter();

  constructor(private ref: ChangeDetectorRef, private UptimetableService: UptimetableService ) {

   }

  ngOnInit() {

    
  }

  Delete(group_name: string)
  {

    this.UptimetableService.deleteGroup(group_name).subscribe(
      (result) => {
          var a = result.json();
          if(a!=null)
          {
          }
          else{
          }
    });

  }


}
