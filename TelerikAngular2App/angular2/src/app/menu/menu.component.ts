import { Component, OnInit, trigger, style, animate, transition, state } from '@angular/core';
import { UserService } from '../core/services/user.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translate3d(0, 0, 0)'
      })),
      state('out', style({
        transform: 'translate3d(-125%, 0, 0)'
      })),
      transition('in => out', animate('400ms ease-in-out')),
      transition('out => in', animate('400ms ease-in-out'))
    ]),
  ]
})

export class MenuComponent implements OnInit {
  menuState: string = 'in';
  userIsAuthorized: boolean = false;
  private hideWish: boolean = true; 
  private hideVisited: boolean = true;

  constructor(private userService: UserService) {
    // Do stuff
  }
  ngOnInit() {
    if (this.userService.checkIfUserIsAuthorized()) {
      this.userIsAuthorized = true;
    }
  }

  toggleMenu() {
    this.menuState = this.menuState === 'out' ? 'in' : 'out';
  }

  toggleWish(){
        if(this.hideWish){
            this.hideWish = false;
        }
        else{
            this.hideWish = true;
    }
  }

  toggleVisited(){
        if(this.hideVisited){
            this.hideVisited = false;
        }
        else{
            this.hideVisited = true;
    }
  }


}