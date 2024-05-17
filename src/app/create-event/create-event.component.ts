import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AddEvent } from 'src/app/models/addevent';
import { Category } from 'src/app/models/category';
import { Locations } from 'src/app/models/location';
import { EventService } from 'src/app/services/event.service';
import ValidateForm from '../helper/validateform';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-event',
  templateUrl: './create-event.component.html',
  styleUrls: ['./create-event.component.css']
})
export class CreateEventComponent implements OnInit {
  CatArray: Category[] = [];
  LocArray: Locations[] = [];
  Eventformgroup!: FormGroup;

  obj: AddEvent = {
    venueName: '',
    locationID: 0,
    categoryID: 0,
    userID: 0,
    eventName: '',
    eventDescription: '',
    eventStartDate: '',
    eventEndDate: '',
    totalPlatinumSeats: 0,
    totalGoldSeats: 0,
    totalSilverSeats: 0,
    platinumSeatPrice: 0,
    goldSeatPrice: 0,
    silverSeatPrice: 0
  };

  constructor(
    private fb: FormBuilder, 
    private eventServ: EventService,
    private toast:NgToastService,
    private route:Router
    ) {}

  ngOnInit(): void {
    this.Eventformgroup = this.fb.group({
      categoryId: ['', Validators.required],
      eventName: ['', Validators.required],
      venueName: ['', Validators.required],
      location: ['', Validators.required],
      eventDescription: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      platinumPrice: ['', Validators.required],
      goldPrice: ['', Validators.required],
      silverPrice: ['', Validators.required],
      totalPlatinum: ['', Validators.required],
      totalGold: ['', Validators.required],
      totalSilver: ['', Validators.required]
    });

    this.eventServ.GetEventCategories().subscribe(data => {
      this.CatArray = data;
    });

    this.eventServ.GetLocations().subscribe(data => {
      this.LocArray = data;
    });
  }

  OnSubmit() {
    if (this.Eventformgroup.valid) {
      this.obj.categoryID = this.Eventformgroup.value.categoryId;
      this.obj.userID = parseInt(localStorage.getItem('userid') || '1');
      this.obj.eventName = this.Eventformgroup.value.eventName;
      this.obj.venueName = this.Eventformgroup.value.venueName;
      this.obj.locationID = this.Eventformgroup.value.location;
      this.obj.eventDescription = this.Eventformgroup.value.eventDescription;
      this.obj.eventStartDate = this.Eventformgroup.value.startDate;
      this.obj.eventEndDate = this.Eventformgroup.value.endDate;
      this.obj.platinumSeatPrice = this.Eventformgroup.value.platinumPrice;
      this.obj.goldSeatPrice = this.Eventformgroup.value.goldPrice;
      this.obj.silverSeatPrice = this.Eventformgroup.value.silverPrice;
      this.obj.totalPlatinumSeats = this.Eventformgroup.value.totalPlatinum;
      this.obj.totalGoldSeats = this.Eventformgroup.value.totalGold;
      this.obj.totalSilverSeats = this.Eventformgroup.value.totalSilver;

      this.eventServ.AddNewEvent(this.obj).subscribe({
        next: (data) => {
          console.log('Event added successfully:', data);
          this.toast.error({ detail: "ERROR", summary: "Successfully added", duration: 2000 });
          this.route.navigate(['payment'])
        },
        error: (err) => {
          console.error('Error adding event:', err);
        }
      });
    } else {
      alert("Invalid Form");
      ValidateForm.validateAllFormFields(this.Eventformgroup);
      console.error('Form is invalid');
    }
  }
}
