import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../models/User';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Login } from '../models/Login';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl: string = "https://localhost:7238/api/User/";
  private userPayload : any;

  constructor(private http: HttpClient, private route: Router) {
    this.userPayload = this.decodedToken();
   }

  getUser(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }
  loginUser(obj: Login): Observable<Login> {
    return this.http.post<User>(`${this.baseUrl}authenticate`, obj);
  }
  addUser(obj: User): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}register`, obj);
  }

  storeToken(tokenValue : string){
    localStorage.setItem('token',tokenValue)
  }
  getToken(){
    return localStorage.getItem('token')
  }

  decodedToken(){
    const jwtHelper = new JwtHelperService();
    const token = this.getToken()!;
    console.log(jwtHelper.decodeToken(token));
    return jwtHelper.decodeToken(token);
  }

  signOut(){
    localStorage.clear();
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token') //!!indicates boolean
  }

  getFullNameFromToken(){
    if(this.userPayload){
      return this.userPayload.name;
    }
  }
  getRoleFromToken(){
    if(this.userPayload){
      return this.userPayload.role;
    }
  }
}
