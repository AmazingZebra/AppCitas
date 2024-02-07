import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { IMember } from '../../_models/imember';
import { IUser } from '../../_models/iuser';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {

  member: IMember | undefined;
  user: IUser | null=null;

  constructor(private accountService: AccountService,
    private memberService: MembersService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: user => this.user=user
      })
  }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember():void {
    if (!this.user) return;

    this.memberService.getMember(this.user.username).subscribe({
      next:member =>this.member=member
      })
  }
}