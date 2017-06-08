import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../core/services/movie.service'
import { Movie } from '../../core/entities/movie';

@Component({
    selector: "movie-list",
    templateUrl: './movie-top.component.html',
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
            .search-results{
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
`]
})

export class MovieTopComponent {

    public movies: Movie[];

    constructor(private movieService: MovieService) {
    }

    ngOnInit() {
        this.loadMovies();
    }

    loadMovies() {
        this.movieService.getMoviesTop10()
            .subscribe(data => this.movies = data);
    }
}