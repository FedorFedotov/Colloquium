
import { Injectable, Inject, Component, Input, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Company } from '../../classes/company'
import { Group } from '../../classes/group'
import { Groupchat } from '../../classes/groupchat'
import { CompleterService, CompleterData } from 'ng2-completer';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { ChatService } from '../../services/chat-service/chat.service'

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit 
{
  @Input() group: Company;
  @Input() source: boolean;
  @Output() groupDeleted = new EventEmitter();
  cpossible:boolean=false;
  dpossible:boolean=false;
  groupchats:Groupchat[]=[];
 
 
  constructor(private ref: ChangeDetectorRef, private ChatService: ChatService) {

   }

  ngOnInit() {

    

    
  }

  // Check()
  // {

  //   this.ChatService.GetAllGroupChats().subscribe(
  //     (result) => {
  //         var a = result.json();
  //         if(a!=null && a.length!=0)
  //         { 
  //           this.groupchats=a;
  //           if (this.groupchats.find(v=> v.groupchat_name === this.group.group_name)!=undefined)
  //           {
  //             this.cpossible=false;
  //             this.dpossible=true;
  //             this.ref.detectChanges();
  //           }
  //           else 
  //           {
  //             this.cpossible=true;
  //             this.dpossible=false;
  //             this.ref.detectChanges();
  //           }
  //         }
  //         else{
  //         }
  //   });


  // }

  // CreateChat()
  // {
  //   var gcvm = new Groupchat();
  //   gcvm.groupchat_name = this.group.group_name;
  //   this.ChatService.PostChat(gcvm).subscribe(
  //     (result) => {
  //         var a = result.json();
  //         if(a!=null)
  //         { 
  //            this.cpossible=false;
  //            this.dpossible=true;
  //            this.ref.detectChanges();
  //         }
  //         else{
  //           this.cpossible=true;
  //           this.dpossible=false;
  //           this.ref.detectChanges();
  //         }
  //   });
  // }

  // DeleteChat()
  // {
  //   this.ChatService.DeleteGroupChat(this.group.group_name).subscribe(
  //     (result) => {
  //         var a = result.json();
  //         if(a!=null)
  //         { 
  //            this.cpossible=true;
  //            this.dpossible=false;
  //            this.ref.detectChanges();
  //         }
  //         else{
  //           this.cpossible=false;
  //           this.dpossible=true;
  //           this.ref.detectChanges();
  //         }
  //   });
  // }


}
