import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Track} from "../_modules/track";
import {Observable} from "rxjs";
import {Member} from "../_modules/member";
import {PaginatedResult} from "../_models/pagination";
import {map} from "rxjs/operators";

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
  tracks: Track[] = [];
  paginatedResult: PaginatedResult<Track[]> = new PaginatedResult<Track[]>();

  constructor(private http: HttpClient) { }

  getTracks(page?: number, itemsPerPage?: number){
    let params = new HttpParams();

    if(page !== null && itemsPerPage !== null){
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    return this.http.get<Track[]>(this.baseUrl + 'track', {observe: 'response', params}).pipe(
      map(response => {
        this.paginatedResult.result = response.body;
        if(response.headers.get('Pagination') !== null) {
          this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return this.paginatedResult;
      })
    );
  }

  getTrack(trackName){
    return this.http.get<Track>(this.baseUrl+'track/'+trackName, httpOptions);
  }
}
