import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';
import { MovieService } from '../../core/services/movie.service'
import { Movie } from '../../core/entities/movie';
import 'rxjs/add/operator/switchMap';

@Component({
    selector: 'movie-details',
    templateUrl: './movie-details.component.html',
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
                padding-top:10px;
                width:40%;
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
export class MovieDetailsComponent {
    private movie: Movie;
    constructor(private movieService: MovieService, private route: ActivatedRoute, ) {

    }
    ngOnInit() {
        let id = this.route.snapshot.params['id'];
        this.loadMovieDetails(id);
    }

    loadMovieDetails(id: any) {
        this.movieService.getMovieById(id)
            .subscribe(data => this.movie = data);
    }

    getMovieDetails() {

    }
}
