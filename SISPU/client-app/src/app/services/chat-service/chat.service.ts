import { Injectable, EventEmitter } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Groupchat } from '../../classes/groupchat'
import { CustomQueryEncoderHelper } from '../../helpers/custom-query-encode.helper'
import { UserTokenStorage } from '../../classes/user-token-storage';
import { HttpClient } from '@angular/common/http';
import { Message } from '../../classes/message'

import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/catch'

@Injectable({
  providedIn: 'root'
})
export class ChatService {
 

  baseUrl="/api/chat";
  private headers: Headers;
  public uploadEvent: EventEmitter<any> = new EventEmitter();

  constructor(private http: Http) {
      this.http = http;
      this.headers = new Headers();
      this.headers.append('Content-Type', 'application/json');
      //this.headers.append('Authorization', 'Bearer ' + UserTokenStorage.getInstance().getUserToken());
 }


    GetMessages(GroupChatName: string)  
    {
      return this.http.get(this.baseUrl + "/" + GroupChatName, {headers: this.headers});
    }

    GetAllGroupChats()  
    {
      return this.http.get(this.baseUrl, {headers: this.headers});
    }
  
    PostMessage(message: Message)
    {
      return this.http.post(this.baseUrl + "/message", JSON.stringify(message) ,{headers: this.headers});
    }
  
    PostChat(groupchat: Groupchat)  
    {
      return this.http.post(this.baseUrl + "/groupchat", JSON.stringify(groupchat) ,{headers: this.headers});
    }

    PostChats(groupchats: Groupchat[])  
    {
      return this.http.post(this.baseUrl, JSON.stringify(groupchats) ,{headers: this.headers});
    }

    DeleteGroupChat(GroupChatName: string)
    {
      return this.http.delete(this.baseUrl + "/" + GroupChatName, {headers: this.headers});
    }

}
