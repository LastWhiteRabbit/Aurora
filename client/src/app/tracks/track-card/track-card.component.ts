import {Component, Input, OnInit} from '@angular/core';
import {Track} from "../../_modules/track";

@Component({
  selector: 'app-track-card',
  templateUrl: './track-card.component.html',
  styleUrls: ['./track-card.component.css']
})
export class TrackCardComponent implements OnInit {
  @Input() track: Track;

  constructor() { }

  ngOnInit(): void {
  }

}
