import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-homescreen',
  templateUrl: './homescreen.component.html',
  styleUrls: ['./homescreen.component.css']
})
export class HomescreenComponent {
  constructor(
    private route : Router,
    private user : UserService
  ){}

  onBookEventClicked(){
    localStorage.setItem("role","user");
    this.route.navigate(['login']);
    // this.route.navigate(['register'], { queryParams: { role: 'user' } });
  }
  
  onOrganizeEventClicked(){
    localStorage.setItem("role","organizer");
    this.route.navigate(['login']);
    // this.route.navigate(['register'], { queryParams: { role: 'organizer' } }); 
  }
}
