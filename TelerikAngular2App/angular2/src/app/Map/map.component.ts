/* 
 * @author RAJAN G
 */
import { Component, ViewContainerRef, OnInit, NgZone, Output, EventEmitter, ViewEncapsulation } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Overlay } from 'angular2-modal';
import { Modal } from 'angular2-modal/plugins/bootstrap';
import { GoogleplaceDirective } from '../core/directives/googleplace.directive';
import { IMarker, IMarkerToSave } from '../core/entities/marker'
import { UserService } from '../core/services/user.service';
import { MarkerService } from '../core/services/marker.service';
import { MapsAPILoader } from 'angular2-google-maps/core';
import { UUID } from 'angular2-uuid';
import { WEBAPI_URL } from '../core/app-constants';
import { DropZoneUploadComponent } from '../dropzone-upload/dropzone-upload.component';
import { DropzoneConfigInterface } from 'angular2-dropzone-wrapper';
import { Observable, Observer } from 'rxjs';

@Component({
  selector: 'map-trip',
  styleUrls: ['./map.component.scss'],
  templateUrl: './map.component.html'
})

export class MapComponent {
  // google maps zoom level
  pageTitle: string = 'Google Maps';
  zoom: number = 2;

  // initial center position for the map
  lat: number = 0;
  lng: number = 10;
  public address: Object;
  markers: IMarker[] = new Array();
  markerToSave: IMarkerToSave;
  isEditMode: boolean = false;
  selectedMarkerId: string;
  DROPZONE_CONFIG: DropzoneConfigInterface;
  openModalWindow: boolean = false;
  imagePointer: number;
  images: any;
  userIsAuthorized: boolean;
  editButtonVisible: boolean;
  placeName: string = "New Place";


  constructor(overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal, private userService: UserService,
    private ngZone: NgZone, private mapsAPILoader: MapsAPILoader, private markerService: MarkerService) {
    overlay.defaultViewContainer = vcRef;
  }

  ngOnInit() {
    if (this.userService.checkIfUserIsAuthorized()) {
      this.userIsAuthorized = true;
      var userMarkers = this.userService.getUserMarkers()
        .subscribe(data => this.markers = data,
        err => console.log(err));

    }
    else {
      this.userIsAuthorized = false;
    }
  }

  getAddress(place: Object) {
    this.address = place['formatted_address'];
    var location = place['geometry']['location'];
    var searchLat = location.lat();
    var searchlng = location.lng();
    var label = place['formatted_address'];
    let uuid = UUID.UUID();
    this.markers.push({
      id: uuid,
      lat: searchLat,
      lng: searchlng,
      draggable: true,
      label: label,
      isOpen: true
    });
    this.isEditMode = this.userIsAuthorized ? true : false;
    this.lat = searchLat;
    this.lng = searchlng;
    this.zoom = 9;
    this.selectedMarkerId = uuid;
    this.dropZoneConfig(searchLat, searchlng);
  }

  AddPlace() {
    this.modal.alert()
      .size('lg')
      .showClose(true)
      .title('Add new place')
      .body(`<map-add-place></map-add-place>`)
      .open();
  }

  savePlace(index: number) {
    var marker = this.markers[index];
    marker.IsSaved = true;
    this.savePlaceToDB(marker);
    this.isEditMode = false;
  }

  savePlaceToDB(marker: any) {
    var markerId: any;
    this.userService.saveUserPlace(marker).subscribe(
      data => markerId = data);
    this.isEditMode = false;
  }

  updateUserPlace(index: number) {
    var markerId: any;
    this.userService.updateUserPlace(this.markers[index]).subscribe(
      data => markerId = data);
    this.isEditMode = false;
  }

  editPlace() {
    this.isEditMode = true;
  }
  close() {

  }


  removePlace(Id: string, index: number) {
    var success: any;
    if (this.userService.checkIfUserIsAuthorized()) {
      this.userService.deleteUserPlace(Id).subscribe(
        data => success = data);

      for (var i = 0; i < this.markers.length; i++)
        if (this.markers[i].id === Id) {
          this.markers.splice(i, 1);
          break;
        }
    }
    else {
      this.markers.splice(index, 1);
    }
  }

  clickedMarker(label: string, index: number, markerId: string, lat: any, lng: any) {
    this.selectedMarkerId = markerId;
    this.dropZoneConfig(lat, lng);
    this.isEditMode = false;
    if (this.userService.checkIfUserIsAuthorized()) {
      this.getMarkerImages(markerId)
    }
  }

  getMarkerImages(markerId: string) {
    this.markerService.getImagesForMarker(markerId)
      .subscribe(data => this.images = data);
  }

  mapClicked($event: MouseEvent) {
    let uuid = UUID.UUID();

    this.selectedMarkerId = uuid;
    var latlng = { lat: parseFloat($event.coords.lat), lng: parseFloat($event.coords.lng) };
    this.getPlaceNameByLatAndLng(latlng).subscribe(name => {
      this.markers[this.markers.length - 1].label = name;
    });
    this.markers.push({
      id: uuid,
      lat: $event.coords.lat,
      lng: $event.coords.lng,
      label: "New place",
      draggable: true,
      isOpen: true,
    });

    this.isEditMode = this.userIsAuthorized ? true : false;
    this.dropZoneConfig($event.coords.lat, $event.coords.lng);
  }

  getPlaceNameByLatAndLng(latLng: any) {
    var geocoder = new google.maps.Geocoder();
    return Observable.create(observer => {
      geocoder.geocode({ 'location': latLng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
          var getPlaceName = results[1].formatted_address;
          observer.next(getPlaceName);
          observer.complete();
        } else {
          console.log('Error - ', results, ' & Status - ', status);
          observer.next({});
          observer.complete();
        }
      });
    });
  }

  markerDragEnd(m: IMarker, $event: MouseEvent) {
   // console.log('dragEnd', m, $event);
  }

  onUploadSuccess(index: any) {
    this.markers[index].IsSaved = true;
  }

  dropZoneConfig(lat: any, lng: any) {
    this.DROPZONE_CONFIG = {
      server: WEBAPI_URL + 'FileUpload/' + this.selectedMarkerId,
      headers: { "Authorization": "Bearer " + this.userService.getUserAccessToken(), "lat": lat, "lng": lng }
    };
  }


}