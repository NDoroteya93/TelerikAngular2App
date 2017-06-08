import { NgModule, ApplicationRef } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule,JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { OAuthService } from 'angular2-oauth2/oauth-service';
import {UserService} from './core/services/user.service';
import { MarkerService } from './core/services/marker.service';
import { AgmCoreModule } from 'angular2-google-maps/core';
import { GoogleplaceDirective } from './core/directives/googleplace.directive';
import { ModalModule } from 'angular2-modal';
import { BootstrapModalModule } from 'angular2-modal/plugins/bootstrap';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { DropzoneModule } from 'angular2-dropzone-wrapper';
import { DropzoneConfigInterface } from 'angular2-dropzone-wrapper';
import { WEBAPI_URL } from './core/app-constants';
import { UUID } from 'angular2-uuid';
import {ImageModal} from 'angular2-image-popup/directives/angular2-image-popup/image-modal-popup';
import {ImageViewerModule } from 'ng-image-viewer';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { ChartComponent } from './chart/chart.component';

import { AppComponent } from './app.component';
import { AuthenticationComponent } from './authentication/authentication.component';
import { MapComponent } from './map/map.component';
import { MapSearchComponent } from './map/map-search/map-search.component';
import { MapAddPlaceComponent } from './map/map-add-place/map-add-place.component';
import { DropZoneUploadComponent } from './dropzone-upload/dropzone-upload.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { MenuComponent } from './menu/menu.component';
import { ImageViwerComponent } from './shared/image-viwer/image-viwer.component';import { ApiService } from './shared';
import { VisitPlaceComponent } from './visit-place/visit-place.component';
import { WishListComponent } from './wish-list/wish-list.component';
import { routing } from './app.routing';

import { removeNgStyles, createNewHosts } from '@angularclass/hmr'; 

const DROPZONE_CONFIG: DropzoneConfigInterface = {
  // Change this to your upload POST address: 
  // server: WEBAPI_URL + 'FileUpload',
  maxFilesize: 50,
  acceptedFiles: 'image/*',
 // headers : {"Authorization": "Bearer " + this.oauthService.getAccessToken()}
};

@NgModule({

  imports:[
    BrowserModule,
    HttpModule,
    JsonpModule,
    FormsModule,
     AgmCoreModule.forRoot({apiKey: 'AIzaSyDjv6zBrjJyAUFWVdFdxCbL9pM_DLbUgJI', libraries: ["places"]}) ,
	 ModalModule.forRoot(),
    BootstrapModalModule, NgbModule.forRoot(),
     ReactiveFormsModule,
      DropzoneModule.forRoot(DROPZONE_CONFIG),
      routing ,
      ImageViewerModule,
      ChartsModule
      ],
	declarations:[
      AppComponent,
      HomeComponent,
      MenuComponent,
      AboutComponent,
      AuthenticationComponent,
      MapComponent,
      MapSearchComponent,
      GoogleplaceDirective,
      MapAddPlaceComponent,
      DropZoneUploadComponent,
      ImageModal,
      ImageViwerComponent,
      VisitPlaceComponent,
      WishListComponent, 
      ChartComponent 
      ],
	providers:[
    OAuthService,
    UserService,
    ApiService,
    MarkerService
    ],
    bootstrap:[AppComponent]
})
export class AppModule {
  constructor(public appRef: ApplicationRef) {}
  hmrOnInit(store) {
    console.log('HMR store', store);
  }
  hmrOnDestroy(store) {
    let cmpLocation = this.appRef.components.map(cmp => cmp.location.nativeElement);
    // recreate elements
    store.disposeOldHosts = createNewHosts(cmpLocation);
    // remove styles
    removeNgStyles();
  }
  hmrAfterDestroy(store) {
    // display new elements
    store.disposeOldHosts();
    delete store.disposeOldHosts;
  }
}
