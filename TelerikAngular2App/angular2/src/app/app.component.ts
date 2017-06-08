import { Component, trigger, state, style, transition, animate } from '@angular/core';

import {AuthenticationComponent } from './authentication/authentication.component'

import { ApiService } from './shared';
import { OAuthService } from 'angular2-oauth2/oauth-service';

import '../style/app.scss';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [
    trigger('slideInOut', [
      state('in', style({
        transform: 'translate3d(0, 0, 0)'
      })),
      state('out', style({
        transform: 'translate3d(100%, 0, 0)'
      })),
      transition('in => out', animate('400ms ease-in-out')),
      transition('out => in', animate('400ms ease-in-out'))
    ]),
  ]
})

export class AppComponent {

menuState:string = 'out';
  constructor(private api: ApiService, private oauthService: OAuthService) {
    // Login-Url
        this.oauthService.loginUrl = 'https://localhost:44310/identity/connect/authorize'; // Id-Provider?
        // URL of the SPA to redirect the user to after login
        this.oauthService.redirectUri = 'http://localhost:3000/';
        // The SPA's id. Register SPA with this id at the auth-server
        this.oauthService.clientId = 'spa-demo';
        // The name of the auth-server that has to be mentioned within the token
        this.oauthService.issuer = 'https://localhost:44310/identity';
        // set the scope for the permissions the client should request
        this.oauthService.scope = 'openid roles telerikangular2api';
        // set to true, to receive also an id_token via OpenId Connect (OIDC) in addition to the
        // OAuth2-based access_token
        this.oauthService.oidc = true;
        // Use setStorage to use sessionStorage or another implementation of the TS-type Storage
        // instead of localStorage
        this.oauthService.setStorage(sessionStorage);
        // To also enable single-sign-out set the url for your auth-server's logout-endpoint here
        this.oauthService.logoutUrl = 'https://localhost:44310/identity/connect/endsession?id_token={{id_token}}';
        // This method just tries to parse the token within the url when
        // the auth-server redirects the user back to the web-app
        // It dosn't initiate the login
        this.oauthService.tryLogin({});
          
    // Do something with api
  }
   toggleMenu() {
        this.menuState = this.menuState ==='out' ? 'in' : 'out';
    }

  
}
