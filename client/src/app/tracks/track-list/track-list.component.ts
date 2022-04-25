import { Component, OnInit } from '@angular/core';
import {Pagination} from "../../_models/pagination";
import {Track} from "../../_modules/track";
import {TracksService} from "../../_services/tracks.service";

@Component({
  selector: 'app-track-list',
  templateUrl: './track-list.component.html',
  styleUrls: ['./track-list.component.css']
})
export class TrackListComponent implements OnInit {
  tracks: Track[];
  pagination: Pagination;
  pageNumber = 1;
  pageSize = 15;

  constructor(private trackService: TracksService) { }

  ngOnInit(): void {
    this.loadTracks();
  }
  loadTracks(){
    this.trackService.getTracks(this.pageNumber, this.pageSize).subscribe(response =>{
      this.tracks = response.result;
      this.pagination = response.pagination;
    })
  }
  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadTracks();
  }

}
