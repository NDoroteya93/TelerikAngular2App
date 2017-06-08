import { Component, ViewContainerRef } from '@angular/core';
import { Overlay } from 'angular2-modal';
import { Modal } from 'angular2-modal/plugins/bootstrap';
import { MapSearchComponent } from '../map-search/map-search.component';

@Component({
  selector: 'map-add-place',
  templateUrl: './map-add-place.component.html'
  })

  export class MapAddPlaceComponent{
      constructor(overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal) {
              overlay.defaultViewContainer = vcRef;

      }

  }