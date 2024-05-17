import { Injectable } from "@angular/core";
import { CanActivate, Router, UrlTree } from "@angular/router";
import { NgToastService } from "ng-angular-popup";
import { UserService } from "../services/user.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate{
  constructor(private user: UserService, private route: Router, private toast: NgToastService) {}

  canActivate() : boolean {
    if (this.user.isLoggedIn()) {
      return true;
    } else {
      console.log("login first");
      this.toast.error({ detail: "ERROR", summary: "Please login first" });
      this.route.navigate(['login']);
      return false;
    }
  }
}
