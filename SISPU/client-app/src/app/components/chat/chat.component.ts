import { Injectable, Inject, Component, Input, OnInit, OnDestroy, Output, EventEmitter } from '@angular/core';
import { Groupchat } from '../../classes/groupchat'
import { Message } from '../../classes/message'
import { User } from '../../classes/user'
import { CompleterService, CompleterData } from 'ng2-completer';
import { ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { ChatService } from '../../services/chat-service/chat.service';


@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  @Input() groupchat: Groupchat;
  @Output() groupchatDeleted = new EventEmitter();
  messages: Message[];
  constructor(private ref: ChangeDetectorRef, private ChatService: ChatService) { }

  ngOnInit() {

    
  }

  Check()
  {
    this.ChatService.GetMessages(this.groupchat.groupchat_name).subscribe(
      (result) => {
          var a = result.json();
          if(a!=null && a.length!=0)
          { 
            console.log(a);
            var gc = new Array<Message>();
            gc = [];
            gc = a;
            this.messages = gc;
            this.ref.detectChanges();
          }
          else{
          }
    }); 
  }

}
