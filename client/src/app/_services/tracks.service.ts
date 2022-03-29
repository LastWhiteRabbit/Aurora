import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Track} from "../_modules/track";
import {Observable} from "rxjs";

const httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer '+ JSON.parse(localStorage.getItem('user')).token
  })
}

@Injectable({
  providedIn: 'root'
})
export class TracksService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTracks(){
    return this.http.get<Track[]>(this.baseUrl + 'track', httpOptions);
  }

  getTrack(trackName){
    return this.http.get<Track>(this.baseUrl+'track/'+trackName, httpOptions);
  }
}
