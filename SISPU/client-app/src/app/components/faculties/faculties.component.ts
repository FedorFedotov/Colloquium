
import { Injectable, Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { DOCUMENT } from "@angular/platform-browser";
import { HttpModule, Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { FacultyService } from '../../services/faculty-service/faculty.service';
import { GroupService } from '../../services/group-service/group.service';
import { UpfacultyService } from '../../services/upfaculty-service/upfaculty.service';
import { Faculty } from '../../classes/faculty';
import { Facultyjson } from '../../classes/facultyjson';

import 'rxjs/add/operator/share';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch';

@Component({
  selector: 'app-faculties',
  templateUrl: './faculties.component.html',
  styleUrls: ['./faculties.component.css'],
})
export class FacultiesComponent implements OnInit {

  faculties: Faculty[]=[];
  jsonfaculties: Facultyjson[]=[];
  clearfaculties: Faculty[]=[];
  subscription: Subscription;
  subscription1: Subscription;
  selectedFaculty: Faculty;
  isButtonHidden: boolean = true;
  Loading: string = 'Список факультетов пуст';
  source: boolean = false; // true = my server works
  Info: string = '';

  constructor(private FacultyService: FacultyService, private UpfacultyService: UpfacultyService, private GroupService: GroupService) { }


  ngOnInit() {

    this.UpfacultyService.getAllFaculties().subscribe(
      (result) => {
          var a = result.json();
         if(a!=null && a.length!=0)
         { this.source = true;
            var gt = new Array<Facultyjson>();
           gt = [];
            gt = a;
          this.jsonfaculties=gt;
          }
          else{
          }
    });


    this.subscription = this.FacultyService.searchEvent.subscribe((newResults) => {
        this.GroupService.loadNext2(newResults);
    });

    this.subscription1 = this.GroupService.searchGroupEvent2.subscribe((jsonfacs) => {
      this.jsonfaculties=[];
    this.jsonfaculties=jsonfacs;
    });

  }

  DownloadFaculties() {
    
    this.FacultyService.loadNext();
    this.Loading='Идет загрузка, подождите';
  }

  UploadFaculties()
  {
 
    if ( this.jsonfaculties.length>0) 
    {

      this.UpfacultyService.UploadFaculties(this.jsonfaculties).subscribe(
        (result) => {
            var a = result.json();
            if(a!=null)
            {
              this.Info=a.ToString;
            }
            else{
            }
      });

  
    }
    

  }



  showWindow() {
    let faculty = new Faculty();
    faculty.faculty_id = 0;
    this.faculties.unshift(faculty);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.subscription1.unsubscribe();
  }

  onSelect(faculty: Faculty): void {
    this.selectedFaculty = faculty;
  }

  
  trackById(index, item: Faculty) {
    return item.faculty_id;
  }

}
