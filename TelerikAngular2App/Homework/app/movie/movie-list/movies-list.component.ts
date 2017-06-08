import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../core/services/movie.service'
import { HttpModule } from '@angular/http';
import { Movie } from '../../core/entities/movie';
import { Observable } from 'rxjs';
// import { CoolHttp } from 'angular2-cool-http';
import 'rxjs';

@Component({
    selector: "movie-list",
    templateUrl: './movies-list.component.html',
     styleUrls: [`.imgPoster{
            height:280px;   
            width:180px;
            float:left;
            cursor:pointer;
            }
            a{
                    font-size: 20pt;
                 padding-bottom: 5px;
                  color: #2802ec;
                  text-decoration: none;
            }
            h1{
                text-align:center;
            }
            ul{
                list-style:none;
                clear:both;
            }
            .listHeader li {
                display:inline-block;
            }
            .movieList{
                width:70%;
                margin:0 auto;
            }
            .listContent li {
                clear:both;
            }
            .dvDescription{
                float:left;
                width:60%;
                padding:40px;
            }
            .mvContent{
                width:200px;
            }
            .mvTitle{
                display:block;
            }
            .mvlist{
                padding-top:15px;
                clear:both;
            }
            #dvLoading {
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
export class MoviesListComponent implements OnInit {

    public movies: Movie[];
    private startPage: any = 1;
    private endPage: any = 5;

    constructor(private movieService: MovieService) {
    }

    ngOnInit() {
        this.loadMovies();
    }

    loadMovies() {
        this.movieService.getMovies(this.startPage, this.endPage)
            .subscribe(data => this.movies = data);
    }

    onScrollDown() {
        this.startPage = this.endPage + 1;
        this.endPage = this.endPage + 6;
        this.movieService.getMovies(this.startPage, this.endPage)
            .subscribe(data => { this.movies = this.movies.concat(data) });
    }
}