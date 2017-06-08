import { Component, Input } from '@angular/core';
import { DropzoneConfigInterface } from 'angular2-dropzone-wrapper';
import { WEBAPI_URL } from '../core/app-constants';
import { UserService } from '../core/services/user.service';

@Component({
  selector: 'dropzone-upload',
  templateUrl: './dropzone-upload.component.html'
  })

  export class DropZoneUploadComponent{
      @Input() marker:any;
      constructor(public userService:UserService) {

      }

     public DROPZONE_CONFIG: DropzoneConfigInterface = {
        // Change this to your upload POST address: 
         server: WEBAPI_URL + 'FileUpload/'+ this.marker,
        // maxFilesize: 50,
        // acceptedFiles: 'image/*',
        headers: { "Authorization": "Bearer " + this.userService.getUserAccessToken() }
    };
  }