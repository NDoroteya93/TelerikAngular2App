import { Http, Response, Headers, RequestOptions, URLSearchParams, Jsonp } from '@angular/http';
import { Injectable, Inject } from '@angular/core';
import { IDNTSRV_URL, WEBAPI_URL } from '../app-constants';
import { IImage } from '../entities/image';
import { IMarker } from '../entities/marker';
import { OAuthService } from 'angular2-oauth2/oauth-service';

import { Observable } from 'rxjs/Rx';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';



@Injectable()
export class MarkerService {
    private headers: Headers;
    private params: URLSearchParams;
    private _JSON: any;

    constructor(private http: Http, private oauthService: OAuthService) {
        this.headers = new Headers();
        this.headers.append('Access-Control-Allow-Origin', '*');

        this.params = new URLSearchParams();
        this._JSON = JSON;
    }

    getVisitedPlaces() {
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        this.headers.append('Content-Type', 'application/json; charset=UTF-8');
        return this.http.get(WEBAPI_URL + 'GetVisitedPlaces', { headers: this.headers })
            .map(response => <IMarker[]>response.json());
        //.catch(this.handleError);
    }

    getWishList() {
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        this.headers.append('Content-Type', 'application/json; charset=UTF-8');
        return this.http.get(WEBAPI_URL + 'GetWishList', { headers: this.headers })
            .map(response => <IMarker[]>response.json());
        //.catch(this.handleError);
    }

    getImagesForMarker(markerId: string): Observable<IImage[]> {
        this.headers.set("Authorization", "Bearer " + this.oauthService.getAccessToken())
        this.headers.append('Content-Type', 'application/json; charset=UTF-8');
        return this.http.get(WEBAPI_URL + 'GetImages/' + markerId, { headers: this.headers })
            .map(response => <IImage[]>response.json());
        //.catch(this.handleError);
    }
}