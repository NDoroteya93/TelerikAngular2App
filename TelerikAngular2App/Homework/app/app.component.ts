import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
@Component({
	selector:'demo-app',
	template:`<header></header><router-outlet></router-outlet>`,
	 styleUrls: [`body{
    margin:0;
    background:#000;
}`]
})
export class AppComponent{
	constructor() {
      
    }
}
