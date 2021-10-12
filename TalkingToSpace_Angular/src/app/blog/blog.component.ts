import { Component, OnInit } from '@angular/core';import { UserService} from '../_services/user.service'
import {User} from '../_models/user.model'
import { UserResult } from '../_models/user-result.model';
import {Message} from '../_models/message.model'
import { MessageResult } from '../_models/message-result.model';
import {Reply} from '../_models/reply.model'
import { ReplyResult } from '../_models/reply-result.model';
import { MessageService } from '../_services/message.service';
import {  Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {

  currentMessage: Message = new Message();
  messages: MessageResult = new MessageResult();
  messageList: Message[];

  load: string = 'no-show';
  disabled: string = '';

  constructor(private MessageService: MessageService, private route: Router, public auth: AuthService) {}

  async ngOnInit(): Promise<void> {
    //GET TH GRADES ON LOAD
    this.messages.message_set = [];
    var t = await this.MessageService
      .getAllMessages()
      .then((data) => {
        if (data.success) {

        console.warn(data);
          this.messages = data;
          this.messageList = data.message_set;
        } else {
          alert(data.backendMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });

  }

  async updateMessage() {
    let result = new UserResult();
    this.disabled = 'disabled';
    this.load = '';
    console.warn(this.currentMessage);
    await this.MessageService
      .updateMessage(this.currentMessage)
      .then(
        (data) => {
        result.success = data.success;
        result.backendMessage = data.backendMessage;
        if (result.success) {
          alert('Register Successfully!');
        } else {
          alert(result.backendMessage);
        }
        //this.currentUser = new User();
      }
      )
      .catch((error) => {
        alert(
          error.error.userMessage +
            ' Please make sure you have provided all the values'
        );
      });
    this.disabled = '';
    this.load = 'no-show';
  }

}
