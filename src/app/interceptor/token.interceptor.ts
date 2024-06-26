import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { UserService } from '../services/user.service';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private user: UserService, 
    private toast : NgToastService,
    private router : Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const myToken = this.user.getToken();

    if(myToken){
      request = request.clone({
        setHeaders: {Authorization : `Bearer ${myToken}`}
      })
    }
    return next.handle(request).pipe(
      catchError((err : any) => {
      if(err instanceof HttpErrorResponse){
        if(err.status === 401){
          this.toast.warning({detail : "Warning", summary : "Token is expired, Please login again"});
          this.router.navigate(['login']);
        }
      }
      return throwError(()=> new Error("Some other error occured!"))
      })
    );
  }
}
