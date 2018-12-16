import {Groupchat} from './groupchat'
import {User} from './user'

export class Message {

    id: string = "0";
    message_text: string = "";
    groupchat: Groupchat = new Groupchat();
    user: User = new User();
    date: Date = new Date();

    constructor()
    {
      this.id="";
      this.message_text= "";
      this.groupchat= new Groupchat();
      this.user= new User();
      this.date= new Date();

    }
}
