import { Component, OnInit } from '@angular/core';
import {Member} from "../../_modules/member";
import {MembersService} from "../../_services/members.service";
import {ActivatedRoute} from "@angular/router";
import {User} from "../../_models/user";

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member;

  constructor(private memberService: MembersService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){
    this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe(member =>{
      this.member = member;
    })
  }
}
