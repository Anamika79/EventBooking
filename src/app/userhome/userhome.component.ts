import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserStoreService } from '../services/user-store.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-userhome',
  templateUrl: './userhome.component.html',
  styleUrls: ['./userhome.component.css']
})
export class UserhomeComponent {
  public fullName: string = "";
  public role!: string;


  constructor(
    private route : Router , 
    private user:UserService,
    private userStore:UserStoreService
  ){}
  ngOnInit(){
    this.userStore.getFullNameFromStore().subscribe(val => {
      const fullNameFromToken = this.user.getFullNameFromToken();
      this.fullName = val || fullNameFromToken;
    })

    this.userStore.getRoleFromStore().subscribe(val => {
      const roleFromToken = this.user.getRoleFromToken();
      this.role = val || roleFromToken;
    })
  }
  logout() {
    this.user.signOut();
    this.route.navigate(['homescreen']);
  }
}
