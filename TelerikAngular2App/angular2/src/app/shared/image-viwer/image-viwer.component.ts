import { Component, OnInit, Input, ViewContainerRef, EventEmitter, HostListener } from '@angular/core';
import { Overlay } from 'angular2-modal';
import { Modal } from 'angular2-modal/plugins/bootstrap';

@Component({
    selector: 'image-viwer',
    templateUrl: './image-viwer.component.html',
    styleUrls: ['./image-viwer.component.scss']
})


@HostListener('window:keydown', ['$event'])

export class ImageViwerComponent implements OnInit {
    @Input() images: any;
    openModalWindow: boolean = false;
    imagePointer: number;
    bigImage: boolean = false;
    constructor(overlay: Overlay, vcRef: ViewContainerRef, public modal: Modal) {
        overlay.defaultViewContainer = vcRef;
    }

    ngOnInit() {
    }

    OpenImageModel(imageName: any, images: any) {
        //alert('OpenImages');
        var imageModalPointer;
        for (var i = 0; i < images.length; i++) {
            if (imageName === images[i].name) {
                imageModalPointer = i;
                console.log('jhhl', i);
                break;
            }
        }
        this.openModalWindow = true;
        this.images = images;
        this.imagePointer = imageModalPointer;
    }
    cancelImageModel() {
        this.openModalWindow = false;
    }

    openImage(imageName: any, images: any) {
        this.bigImage = true;
        this.OpenImageModel(imageName, images);
    }

    keyboardInput(event: any) {
        if(event.key === 27){ 
             this.openModalWindow = false;
        }
    }

}

