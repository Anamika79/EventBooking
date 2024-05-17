import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usernavbar',
  templateUrl: './usernavbar.component.html',
  styleUrls: ['./usernavbar.component.css']
})
export class UsernavbarComponent {
  constructor(
    private route : Router , 
    private user:UserService,
  ){}
  logout() {
    this.user.signOut();
    this.route.navigate(['homescreen']);
  }
}
