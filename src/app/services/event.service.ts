import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category } from '../models/category';
import { Observable } from 'rxjs/internal/Observable';
import { Locations } from '../models/location';
import { AddEvent } from '../models/addevent';
 
@Injectable({
  providedIn: 'root'
})
export class EventService {
 
  constructor(private http:HttpClient) { }
  baseUrl="https://localhost:7063/api/Event/";
  GetEventCategories():Observable<Category[]>{
    return this.http.get<Category[]>(this.baseUrl+"getcategories");
  }
 
  GetLocations():Observable<Locations[]>{
    return this.http.get<Locations[]>(this.baseUrl+"getlocations");
  }
 
  AddNewEvent(event:AddEvent):Observable<AddEvent>{
    return this.http.post<AddEvent>(this.baseUrl+"addevent",event);
  }
 
  // GetEventList():Observable<OrganiserEventList[]>{
  //   return this.http.get<OrganiserEventList[]>(this.baseUrl+)
  // }
 
}
