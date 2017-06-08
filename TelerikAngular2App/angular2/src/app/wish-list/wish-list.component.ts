import { Component, OnInit, Input, ViewContainerRef, EventEmitter } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { MarkerService } from '../core/services/marker.service';

@Component({
    selector: 'wish-list',
    templateUrl: './wish-list.component.html',
    styleUrls: ['./wish-list.component.scss']
})
export class WishListComponent implements OnInit {
    PageTitle: string = 'Wish List';
    wishedPlace: any;
    constructor(private userService: UserService, private markerService: MarkerService) {

    }

    ngOnInit() {
        if (this.userService.checkIfUserIsAuthorized()) {
            var wishedPlace = this.markerService.getWishList()
                .subscribe(data => this.wishedPlace = data,
                err => console.log(err));
        }
    }
}

