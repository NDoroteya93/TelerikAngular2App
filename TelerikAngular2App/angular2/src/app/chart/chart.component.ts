import { Component,  OnInit } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import 'ng2-charts/components/charts/charts.js';
import '../../../node_modules/chart.js/src/chart.js';
// import { UserService } from '../core/services/user.service';
// import { MarkerService } from '../core/services/marker.service';
// import { IMarker } from '../core/entities/marker';
// import { VisitPlaceComponent } from '../visit-place/visit-place.component';



@Component({
  selector: 'bar-chart',
  templateUrl: './chart.component.html', 
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent {
  // visitedPlace: IMarker[];
  //   data: number[];
    pageTitle: string = 'Charts';  
  //   constructor(private userService: UserService, private markerService: MarkerService) {

  //   }
  // ngOnInit() { 
  // if (this.userService.checkIfUserIsAuthorized()) {
  //           var visitedPlace = this.markerService.getVisitedPlaces()
  //               .subscribe(data => this.visitedPlace = data,
  //               err => console.log(err));
  //       }
  // }
  
  public barChartOptions:any = {
    scaleShowVerticalLines: false,
    
        scales: {
            xAxes: [{
                stacked: true
            }],
            yAxes: [{
                ticks: {
              beginAtZero: true,
              max: 100,
              min: 0,
              stepSize: 10
            },
            }]
        },
    responsive: true
  };
  public barChartLabels:string[] = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
  public barChartType:string = 'bar';
  public barChartLegend:boolean = true;

  public barChartData:any[] = [
    {data: [ 80, 81, 56, 55, 40,28, 48, 40, 19, 86, 27, 90], label: 'Months'}
  ];
  

  // events
  public chartClicked(e:any):void {
    console.log(e);
  }

  public chartHovered(e:any):void {
    console.log(e);
  }

  //  public getPlacesForMonth(): void {
  //    if(this.visitedPlace != undefined || visitedPlace.length > 0){
  //       for (var i = 0; i < this.visitedPlace.length; i++) {
  //           var count = 0;
  //           var placeMonth = this.visitedPlace[i].CreatedOn.getMonth();
  //           if (this.data[placeMonth] == null) {
  //               for (var a = 0; a < this.visitedPlace.length; a++) {
  //                   if (this.visitedPlace[a].CreatedOn.getMonth() == placeMonth) {
  //                       count++;
  //                   }
  //               }
  //           }
  //           this.data[placeMonth] = count;
  //       }
  //    }
  //       let clone = JSON.parse(JSON.stringify(this.barChartData));
  //   clone[0].data = data;
  //   this.barChartData = clone

  //   }


}