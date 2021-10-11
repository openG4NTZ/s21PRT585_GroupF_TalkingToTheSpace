import { Component, OnInit } from '@angular/core';
import { UserService} from '../_services/user.service'
import {User} from '../_models/user.model'
import { UserResult } from '../_models/user-result.model';
import {  Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  currentUser: User = new User();
  users: UserResult = new UserResult();
  usersList: User[];

  load: string = 'no-show';
  disabled: string = '';

  constructor(private UserService: UserService, private route: Router, public auth: AuthService) {}

  async ngOnInit(): Promise<void> {
    //GET TH GRADES ON LOAD
    this.users.result_set = [];
    var t = await this.UserService
      .getAllUsers()
      .then((data) => {
        if (data.success) {

        console.warn(data);
          this.users = data;
          this.usersList = data.result_set;
        } else {
          alert(data.userMessage);
        }
      })
      .catch((error) => {
        alert(error);
      });

  }

  async signup() {
    let result = new UserResult();
    this.disabled = 'disabled';
    this.load = '';
    this.currentUser.user_point=1;
    console.warn(this.currentUser);
    await this.UserService
      .addUser(this.currentUser)
      .then(
        (data) => {
        result.success = data.success;
        result.userMessage = data.userMessage;
        if (result.success) {
          alert('Register Successfully!');
          this.navigateToLogin();
        } else {
          alert(result.userMessage);
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

  navigateToLogin() {
    this.route.navigate(['/login']);
 }

 loginWithRedirect(): void {
  this.auth.loginWithRedirect({ screen_hint: 'signup' });
}

}
