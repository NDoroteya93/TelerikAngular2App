import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { VisitPlaceComponent } from './visit-place/visit-place.component';
import { WishListComponent } from './wish-list/wish-list.component';
import { ChartComponent } from './chart/chart.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'about', component: AboutComponent},
  { path: 'visit-place', component: VisitPlaceComponent},
  { path: 'wish-list', component: WishListComponent}, 
  { path: 'bar-chart', component:  ChartComponent}
];

export const routing = RouterModule.forRoot(routes);
