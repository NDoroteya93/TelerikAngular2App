import {Directive, ElementRef, EventEmitter, Output, NgZone} from '@angular/core';
import {NgModel} from '@angular/forms';
import { FormControl } from "@angular/forms";
import { MapsAPILoader } from 'angular2-google-maps/core';

declare var google:any;

@Directive({
  selector: '[googleplace]',
  providers: [NgModel],
  host: {
    '(input)' : 'onInputChange()'
  }
})
export class GoogleplaceDirective  {
  @Output() setAddress: EventEmitter<any> = new EventEmitter();
  modelValue:any;
  autocomplete:any;
  private _el:HTMLElement;


  constructor(el: ElementRef,private model:NgModel, private mapsAPILoader: MapsAPILoader,  private ngZone: NgZone) {
    this._el = el.nativeElement;
    this.modelValue = this.model;
    var input = this._el;
   // this.autocomplete = new google.maps.places.Autocomplete(input, {});
     this.mapsAPILoader.load().then(() => {
      this.autocomplete = new google.maps.places.Autocomplete(this._el, {});
     
     google.maps.event.addListener(this.autocomplete, 'place_changed', ()=> {
         this.ngZone.run(() => {
      // var place = this.autocomplete.getPlace();
      // this.invokeEvent(place);
      //get the place result
          let place: google.maps.places.PlaceResult = this.autocomplete.getPlace();

          //verify result
          if (place.geometry === undefined || place.geometry === null) {
            return;
          }
          this.invokeEvent(place);
         });
      });
    });
   }

  invokeEvent(place:Object) {
    this.setAddress.emit(place);
  }


  onInputChange() {
  }
}