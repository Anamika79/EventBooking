import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import ValidateForm from '../helper/validateform';
import { UserStoreService } from '../services/user-store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm!: FormGroup;
  // role : string = '';

  constructor(
    private fb : FormBuilder,
    private user: UserService,
    private route: Router,
    private toast: NgToastService,
    private userStore : UserStoreService
  ){}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  onLogin() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);

      this.user.loginUser(this.loginForm.value).subscribe({
        next: (res) => {
          console.log("Login Success : ", this.loginForm.value);
          this.user.storeToken(res.token);
          console.log(res.token);
          const tokenPayload = this.user.decodedToken();
          this.userStore.setFullNameFromStore(tokenPayload.name);
          this.userStore.setRoleForStore(tokenPayload.role);
          console.log(tokenPayload.role);

          if (tokenPayload.role.toLowerCase() === 'user') {
            this.route.navigate(['userhome']); // Navigate to user home if role is user
          } else if (tokenPayload.role.toLowerCase() === 'organizer') {
            this.route.navigate(['create-event']); // Navigate to dashboard if role is organizer
          } else {
            console.error('Invalid role'); // Handle invalid role
          }
        },
        error: (err) => {
          this.toast.error({ detail: "ERROR", summary: "Something went wrong!", duration: 2000 });
          this.loginForm.reset();
        }
      });
    } else {
      console.log("Form is invalid");
      // Mark all form controls as touched to trigger validation messages
      ValidateForm.validateAllFormFields(this.loginForm);
      alert("Invalid Form");
    }
  }
}
