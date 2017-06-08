import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular2-oauth2/oauth-service';
import { UserService } from '../core/services/user.service';
import { UserInfo } from '../core/entities/userInfo';

@Component({
    selector: 'authentication',
    templateUrl: './authentication.component.html',
    styleUrls: ['./authentication.component.scss'],
    providers: [UserService],

})
export class AuthenticationComponent implements OnInit {
    userIsAuthorized: boolean;
    private userInfo: UserInfo;

    menuState: string = 'out';

    constructor(private oAuthService: OAuthService, private userService: UserService) {
    }

    ngOnInit() {
        if (this.userService.checkIfUserIsAuthorized()) {
            this.userIsAuthorized = false;
            this.getUserInfo();
        } else {
            this.userIsAuthorized = true;
        }
    }

    public login() {
        this.oAuthService.initImplicitFlow();
    }

    public logoff() {
        this.oAuthService.logOut();
    }

    public getUserInfo() {
        var userInfo = this.userService.getUserInfo()
            .subscribe(data => this.userInfo = data,
            err => console.log(err));
    }


}