/* 
 * @author RAJAN G
 */
import { Component } from '@angular/core';
import { GoogleplaceDirective } from '../../core/directives/googleplace.directive';

@Component({
    selector: 'map-search',
    templateUrl: './map-search.component.html'
})

export class MapSearchComponent {
    public address: Object;
    getAddress(place: Object) {
        this.address = place['formatted_address'];
        var location = place['geometry']['location'];
        var lat = location.lat();
        var lng = location.lng();
        console.log("Address Object", place);
    }
}