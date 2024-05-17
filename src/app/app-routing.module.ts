import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './guards/auth-guard.guard';
import { HomescreenComponent } from './homescreen/homescreen.component';
import { UserhomeComponent } from './userhome/userhome.component';
import { PaymentComponent } from './payment/payment.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { CreateEventComponent } from './create-event/create-event.component';
import { UsernavbarComponent } from './usernavbar/usernavbar.component';

const routes: Routes = [
  {path:'', component:HomescreenComponent},
  {path:'register', component:RegisterComponent},
  {path:'login' , component:LoginComponent},
  {path:'userhome' , component:UserhomeComponent , canActivate:[AuthGuard]},
  {path:'homescreen', component:HomescreenComponent},
  {path:'payment' , component:PaymentComponent},
  {path:'confirmation' , component:ConfirmationComponent},
  {path:'create-event' , component:CreateEventComponent},
  {path:'usernavbar' , component:UsernavbarComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
