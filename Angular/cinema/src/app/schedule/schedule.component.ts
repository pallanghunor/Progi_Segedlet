import { Component } from '@angular/core';
import { DataService } from '../data.service';
import { MovieModel } from '../movie.model';
import { MovieComponent } from "../movie/movie.component";

@Component({
  selector: 'app-schedule',
  imports: [MovieComponent],
  templateUrl: './schedule.component.html',
  styleUrl: './schedule.component.css'
})
export class ScheduleComponent {

  movies: MovieModel[] = [];
  movieUnderEdit: MovieModel | null = null;

  constructor(private dataService: DataService) {}

  ngOnInit() {
    this.dataService.getMovies().subscribe({
      next: (result: MovieModel[]) => {
        this.movies = result;
      },
      error: (err: any) => {
        console.log(err);
      }
    })
  }

  newMovie() {
    this.movieUnderEdit = {
      id: 0,
      title: '',
      star: '',
      description: '',
      from: '',
      to: '',
      imageBase64: '',

      onAir: '',
      imageUrl: ''
    }
  }

  update(movie: MovieModel) {
    this.movieUnderEdit = {...movie};
    this.movieUnderEdit.from = movie.onAir.split(' - ')[0].replace('.', '-');
    this.movieUnderEdit.to = movie.onAir.split(' - ')[1].replace('.', '-');

  }

  saved(movie: MovieModel){
    if (this.movieUnderEdit && this.movieUnderEdit.id == 0) {
      this.movies.push(movie)
    } else {
      const index = this.movies.findIndex(m => m.id == movie.id);
      this.movies[index] = movie;
    }
    this.movieUnderEdit = null;
  }

  delete(movie: MovieModel) {
    if (confirm('biztos???')) {
      this.dataService.deleteMovie(movie.id).subscribe({
        next: (x: any) => {
          // const index = this.movies.findIndex(m => m.id == movie.id);
          // this.movies.splice(index, 1);

          this.movies = this.movies.filter(m => m.id != movie.id);
        },
        error: (err) => {
          console.log(err)
        }
      })
    }
  }

}
