import { Http, Response, Headers, RequestOptions, URLSearchParams, Jsonp } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { IDNTSRV_URL, WEBAPI_URL } from '../app-constants';
import { UserInfo } from '../entities/userInfo'
import { IMarker, IMarkerToSave } from '../entities/marker';
import { OAuthService } from 'angular2-oauth2/oauth-service';

import { Observable } from 'rxjs/Rx';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';



@Injectable()
export class UserService {

    private headers: Headers;
    private params: URLSearchParams;
    private _JSON: any;

    constructor(private jsonp: Jsonp, private http: Http, private oauthService: OAuthService) {
        this.headers = new Headers();
        this.headers.append('Access-Control-Allow-Origin', '*');

        this.params = new URLSearchParams();
        this._JSON = JSON;
    }
    checkIfUserIsAuthorized() {
        var userToken = this.oauthService.getAccessToken()
        if (userToken != null) {
            return true;
        }
        return false;
    }

    getUserAccessToken(){
         return this.oauthService.getAccessToken()
    }

    getUserInfo(): Observable<UserInfo> {
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        return this.http.get(WEBAPI_URL + 'GetUserInfo', { headers: this.headers }) 
            .map(response => <UserInfo>response.json());
        //.catch(this.handleError);
    }

    getUserMarkers(): Observable<IMarker[]> {
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        return this.http.get(WEBAPI_URL + 'GetUserPlaces', { headers: this.headers }) 
            .map(response => <IMarker[]>response.json());
        //.catch(this.handleError);
    }

    saveUserPlace(placeToSave: IMarker): Observable<IMarker> {
       this.headers.append('Content-Type', 'application/json; charset=UTF-8');
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        var dataToSave = this._JSON.stringify(placeToSave);
        return this.http.post(WEBAPI_URL + 'SavePlace', dataToSave, { headers: this.headers }) 
            .map(response => response.json());
    }

    updateUserPlace(placeToSave: IMarker): Observable<IMarker> {
        this.headers.append('Content-Type', 'application/json; charset=UTF-8');
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        var updatePlace = this._JSON.stringify(placeToSave);
        return this.http.post(WEBAPI_URL + 'UpdatePlace', updatePlace, { headers: this.headers })
            .map(response => response.json());
    }

    deleteUserPlace(placeId: string): Observable<string> {
        this.headers.append('Content-Type', 'application/json; charset=UTF-8');
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())

        let body = this._JSON.stringify({ 'Id': placeId });

        return this.http.get(WEBAPI_URL + 'DeletePlace/' + placeId, { headers: this.headers })
            .map(response => response.json());

    }

    private handleError(error: Response) {
        //  return Observable.throw(error.json().error || 'Server error');
    }


}