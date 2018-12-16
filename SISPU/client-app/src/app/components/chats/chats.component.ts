
import { Injectable, Component, Input, Output, OnInit, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { DOCUMENT } from "@angular/platform-browser";
import { HttpModule, Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ChatService } from '../../services/chat-service/chat.service';
import { Groupchat } from '../../classes/groupchat';
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

  groupchats: Groupchat[]=[];
  safegroupchats: Groupchat[];
  subscription: Subscription;
  selectedGroupchat: Groupchat;
  isButtonHidden: boolean = true;
  Loading: string = 'Список чатов пуст';

  constructor(private ref: ChangeDetectorRef, private ChatService: ChatService) { }


  ngOnInit() {

    this.ChatService.GetAllGroupChats().subscribe(
      (result) => {
          var a = result.json();
          if(a!=null && a.length!=0)
          { 
            console.log(a);
            var gc = new Array<Groupchat>();
            gc = [];
            gc = a;
            this.groupchats = gc;
            this.safegroupchats = gc;
          }
          else{
          }
    }); 


  }

  showWindow() {
    let groupchat = new Groupchat();
    groupchat.id = "";
    this.groupchats.unshift(groupchat);
  }


  Search (searchinput: string)
  {
          var gc = new Array<Groupchat>();
            gc = [];
            gc = this.groupchats;
            this.groupchats = [];
            this.safegroupchats.forEach(element=>
            {
             if ( element.groupchat_name.includes(searchinput)) this.groupchats.push(element);
            })
           this.ref.detectChanges();

  }

  ngOnDestroy() {
    //this.subscription.unsubscribe();
  }

  onSelect(groupchat: Groupchat): void {
    this.selectedGroupchat = groupchat;
  }

  
  trackById(index, item: Groupchat) {
    return item.id;
  }


}
