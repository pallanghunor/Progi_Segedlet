import { Routes } from '@angular/router';
import { CarsComponent } from './cars/cars.component';
import { VoteComponent } from './vote/vote.component';

export const routes: Routes = [
    {path: '', component: CarsComponent},
    {path: 'vote', component: VoteComponent}
];
