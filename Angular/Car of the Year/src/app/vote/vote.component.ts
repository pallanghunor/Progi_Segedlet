import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DataService } from '../data.service';
import { CarModel } from '../car.model';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-vote',
  imports: [FormsModule],
  templateUrl: './vote.component.html',
  styleUrl: './vote.component.css'
})
export class VoteComponent {

  vote = {
    carId: '',
    email: '',
    comment: '',
    tou: false
  }
  cars: CarModel[] = [];
  errorMsg = '';

  constructor(
    private dataService: DataService,
    private route: ActivatedRoute,
    private router: Router) {}

  ngOnInit() {
    this.dataService.getCars('').subscribe({
      next: (result: CarModel[]) => {
        this.cars = result;

        //qryParam olvasása
        this.vote.carId = this.route.snapshot.queryParamMap.get('carId') ?? '';
        console.log(this.vote);
      },
      error: (err: any) => {
        console.log(err);
        this.errorMsg = err.error?.message ?? err.message;
      }
    })
  }

  voteClick() {
    console.log(this.vote); 
    this.errorMsg = '';
    if (!this.vote.carId) {
      this.errorMsg += 'Kérem válassza ki az autót! '
    }
    if (!this.vote.email) {
      this.errorMsg += 'Kérem adja meg az e-mail címét! '
    }
    if (!this.vote.tou) {
      this.errorMsg += 'Kérem fogadja el a felhasználási feltételeket! '
    }
    if (!this.errorMsg) {
      this.dataService.postVote(this.vote).subscribe({
        next: (result: any) => {
          alert('Köszönjük a szavazatát!')
          this.router.navigate(['']);
        },
        error: (err: any) => {
          console.log(err);
          this.errorMsg = err.error?.message ?? err.message;
        }
      })      
    }
  }
}
