import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'loading-screen',
  templateUrl: './loading-screen.component.html',
  styles: [` #dvLoading {
  position: fixed;
  z-index: 999;
  height: 2em;
  width: 2em;
  overflow: show;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}`]
})

export class LoadingScreenComponent {

  private isVisible: boolean = true;

  constructor() { }

  @Input('objectToCheck') asynObject: boolean;

  ngDoCheck() {
    if (this.asynObject) {
      this.isVisible = false;
    }
  }
}
