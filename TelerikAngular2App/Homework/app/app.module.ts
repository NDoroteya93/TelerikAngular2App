import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { InfiniteScrollModule } from 'angular2-infinite-scroll';
import { MovieService } from './core/services/movie.service'
import { RouterModule, Routes }   from '@angular/router';
import {APP_BASE_HREF} from '@angular/common';
// import { CoolLoadingIndicatorModule } from 'angular2-cool-loading-indicator';

import { AppComponent } from './app.component';
import { MoviesListComponent } from './movie/movie-list/movies-list.component';
import { MovieDetailsComponent } from './movie/movie-details/movie-details.component';
import { MovieTopComponent } from './movie/movie-top/movie-top.component';
import { HeaderComponent } from './header/header.component';
import { LoadingScreenComponent } from './loading-screen/loading-screen.component';


const routes: Routes = [
  { path: 'movie-detail/:id', component: MovieDetailsComponent },
  { path: '', component: MoviesListComponent },
  { path: 'movie-top', component: MovieTopComponent }
];

@NgModule({
	imports:[BrowserModule, HttpModule, JsonpModule, FormsModule, InfiniteScrollModule, RouterModule.forRoot(routes)],
	declarations:[AppComponent, MoviesListComponent, MovieDetailsComponent, MovieTopComponent, HeaderComponent, LoadingScreenComponent],
	providers:[MovieService, {provide: APP_BASE_HREF, useValue : '/' }],
	bootstrap:[AppComponent]
})
export class AppModule{}