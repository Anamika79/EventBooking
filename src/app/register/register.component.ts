import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { UserService } from '../services/user.service';
import ValidateForm from '../helper/validateform';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  signupForm!: FormGroup;
  role: string = localStorage.getItem('role') || '';

  constructor(
    private fb:FormBuilder,
    private user:UserService,
    private route:Router,
    private toast: NgToastService,
    // private activatedRoute: ActivatedRoute
    ){}

    ngOnInit(): void {
        this.signupForm = this.fb.group({
          fullName : ['',Validators.required],
          email : ['',[Validators.required, Validators.email]],
          mobile : ['',Validators.required],
          password : ['',Validators.required],
          role: [this.role, Validators.required]
        });
    }
    
    onSubmit(){
      if(this.signupForm.valid){
        console.log(this.signupForm.value);
        //send obj to database
        this.user.addUser(this.signupForm.value).subscribe({
          next : (res)=>{
            alert("User registered");
            this.signupForm.reset();
            this.route.navigate(['login']);
          },
          error:(err)=>{
            this.toast.error({detail:"ERROR",summary:"Something went wrong!", duration:1000});
            this.signupForm.reset();
            console.log(err);
          }
        })
      }
      else{
        console.log("Form is invalid");
        //throw error using toaster
        ValidateForm.validateAllFormFields(this.signupForm);
        alert("Invalid Form");
      }
    }
}
