import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { CarModel } from '../car.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cars',
  imports: [],
  templateUrl: './cars.component.html',
  styleUrl: './cars.component.css'
})
export class CarsComponent {

  manufacturers: {id: number, name: string}[] = [];
  cars: CarModel[] = [];

  constructor(
    private dataService: DataService,
    private router: Router) {}

  ngOnInit() {
    this.dataService.getManufacturers().subscribe({
      next: (result: {id: number, name: string}[]) => {
        this.manufacturers = result;
      },
      error: (err: any) => {
        console.log(err);
      }
    })

    this.selectManufacturer(null);
  }

  selectManufacturer(event: any) {
    const value = event?.target.value ?? '';
    this.dataService.getCars(value).subscribe({
      next: (result: CarModel[]) => {
        this.cars = result;
      },
      error: (err: any) => {
        console.log(err);
      }
    })
  }

  vote(carId: number) {
    this.router.navigate(['vote'], { queryParams: {carId: carId} })
  }
}
