import { Component, OnInit, Input, ViewContainerRef, EventEmitter } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { MarkerService } from '../core/services/marker.service';
import { IMarker } from '../core/entities/marker';

@Component({
    selector: 'visit-place',
    templateUrl: './visit-place.component.html',
    styleUrls: ['./visit-place.component.scss']
})
export class VisitPlaceComponent implements OnInit {
    PageTitle: string = 'Visited Place'
    visitedPlace: IMarker[];
    data: number[];
    constructor(private userService: UserService, private markerService: MarkerService) {

    }

    ngOnInit() {
        if (this.userService.checkIfUserIsAuthorized()) {
            var visitedPlace = this.markerService.getVisitedPlaces()
                .subscribe(data => this.visitedPlace = data,
                err => console.log(err));
        }
    }

    getPlacesForMonth() {
        for (var i = 0; i < this.visitedPlace.length; i++) {
            var count = 0;
            var placeMonth = this.visitedPlace[i].CreatedOn.getMonth();
            if (this.data[placeMonth] == null) {
                for (var a = 0; a < this.visitedPlace.length; a++) {
                    if (this.visitedPlace[a].CreatedOn.getMonth() == placeMonth) {
                        count++;
                    }
                }
            }
            this.data[placeMonth] = count;
        }

    }
}

