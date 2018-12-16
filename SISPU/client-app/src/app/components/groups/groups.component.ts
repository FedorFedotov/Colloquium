
import { Injectable, Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { DOCUMENT } from "@angular/platform-browser";
import { HttpModule, Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { GroupService } from '../../services/group-service/group.service';
import { Group } from '../../classes/group';
import { FacultyService } from '../../services/faculty-service/faculty.service';
import { UpgroupService } from '../../services/upgroup-service/upgroup.service';
import { Faculty } from '../../classes/faculty';
import { CustomQueryEncoderHelper } from '../../helpers/custom-query-encode.helper'
import { Facultiesjson } from '../../classes/facultiesjson'
import { UserTokenStorage } from '../../classes/user-token-storage';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { Company } from '../../classes/company';

import 'rxjs/add/operator/share';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch';

@Component({
  selector: 'app-groups',
  templateUrl: './groups.component.html',
  styleUrls: ['./groups.component.css']
})
export class GroupsComponent implements OnInit {

  groups: Company[]=[];
  safegroups: Company[]=[];
  cleargroups: Company[]=[];
  Loading: string = 'Список компаний пуст';
  faculties: Faculty[];
  subscription: Subscription;
  subscription1: Subscription;
  selectedGroup: Company;
  isButtonHidden: boolean = true;
  Info: string = '';
  source: boolean = false; // true = my server works

  constructor(private ref: ChangeDetectorRef, private GroupService: GroupService, private FacultyService: FacultyService, private UpgroupService: UpgroupService) { }


  ngOnInit() {


   this.UpgroupService.getAllGroups().subscribe(
      (result) => {
        var a = result.json();
          if(a!=null && a.length!=0)
         { this.source = true;
            var gt = new Array<Company>();
           gt = [];
            gt = a;
           this.groups = gt;
           this.safegroups = gt;
         }
         else{
       }
    });


    
    this.subscription = this.FacultyService.searchEvent.subscribe((newResults) => {
      this.GroupService.loadNext(newResults );


    });

    this.subscription1 = this.GroupService.searchGroupEvent.subscribe((newRes) => {
      this.groups=[];
    this.groups=newRes;
    });
    

  }

  DownloadGroups() {
    this.Loading='Идет загрузка, подождите';
    this.FacultyService.loadNext();
  }


  // UploadGroups()
  // {
    

  //   if ( this.groups.length>0) 
  //   {
  //     this.groups.forEach(element => {

  //       this.cleargroups.push(element);
  
  //     });
  
  //     this.UpgroupService.UploadGroups(this.cleargroups).subscribe(
  //       (result) => {
  //           var a = result.json();
  //           if(a!=null)
  //           {
  //             this.Info=a.ToString;
  //           }
  //           else{
  //           }
  //     });
  
  
  //     this.cleargroups =[];
  
  //   }
    

  // }

  // showWindow() {
  //   let group = new Company();
  //   group.group_id = 0;
  //   this.groups.unshift(group);
  // }


  Search (searchinput: string)
  {
          var gc = new Array<Company>();
            gc = [];
            gc = this.groups;
            this.groups = [];
            this.safegroups.forEach(element=>
            {
             if ( element.c_name.includes(searchinput)) this.groups.push(element);
            })
           this.ref.detectChanges();

  }


  ngOnDestroy() {
    this.subscription.unsubscribe();
    this.subscription1.unsubscribe();
  }

  onSelect(group: Company): void {
    this.selectedGroup = group;
  }

  
  trackById(index, item: Group) {
    return item.group_id;
  }

}
