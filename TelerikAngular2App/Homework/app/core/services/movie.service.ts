import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Jsonp, URLSearchParams } from '@angular/http'
import { Injectable, Inject } from '@angular/core';
import { MYFILMS_TOP_API, MYFILMS_ID_API } from '../../core/app-constants'
import { Movie } from '../entities/movie';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/operator/map'

@Injectable()
export class MovieService {

  private headers: Headers;
  private params: URLSearchParams;
  constructor(private jsonp: Jsonp) {
    this.headers = new Headers();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Access-Control-Allow-Origin', '*');
    this.headers.append('Accept', 'application/json');

    this.params = new URLSearchParams();
    this.params.set('token', 'ea219721-4f84-4616-94d1-21619cec64c0');
    this.params.set('format', 'json');
    this.params.set('data', '1');
    this.params.set('callback', 'JSONP_CALLBACK');
  }

  getMovies(statPage: any, endStart: any): Observable<Movie[]> {
    this.params.set('start', statPage);
    this.params.set('end', endStart);

    return this.jsonp.get(MYFILMS_TOP_API, { search: this.params, headers: this.headers })
      .map(response => <Movie[]>response.json().data.movies)
      .catch(this.handleError);
  }

  getMovieById(id: any): Observable<Movie> {
    this.params.set('idIMDB', id);
    return this.jsonp.get(MYFILMS_ID_API, { search: this.params, headers: this.headers })
      .map(response => <Movie>response.json().data.movies[0])
      .catch(this.handleError);
  }

  getMoviesTop10(): Observable<Movie[]> {
    this.params.set('start', '1');
    this.params.set('end', '10');
    return this.jsonp.get(MYFILMS_TOP_API, { search: this.params, headers: this.headers })
      .map(response => <Movie[]>response.json().data.movies)
      .catch(this.handleError);
  }

  private handleError(error: Response) {
    return Observable.throw(error.json().error || 'Server error');
  }

}