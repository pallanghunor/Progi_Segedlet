import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { PaintingsComponent } from './components/paintings/paintings.component';
import { BiddingComponent } from './components/bidding/bidding.component';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'home'},
    { path: 'home', component: HomeComponent},
    { path: 'paintings', component: PaintingsComponent},    
    { path: '**', redirectTo: 'home'},
];
