import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MovieModel } from '../movie.model';
import { DataService } from '../data.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-movie',
  imports: [FormsModule],
  templateUrl: './movie.component.html',
  styleUrl: './movie.component.css'
})
export class MovieComponent {
  @Input() movie!: MovieModel;
  @Output() saved = new EventEmitter<MovieModel>();
  @Output() cancel = new EventEmitter<void>();

  constructor(private dataService: DataService) {}

  save() {
    if (!this.movie.title) {
      return;
    }
    //todo: további kötelező mező ellenőrzések...

    if (this.movie.id == 0) {
      this.dataService.postMovie(this.movie).subscribe({
        next: (result: MovieModel) => {
          this.saved.emit(result);
        },
        error: (err: any) => {
          console.log(err);
        }
      })
    } else {
      this.dataService.putMovie(this.movie).subscribe({
        next: (result: MovieModel) => {
          this.saved.emit(result);
        },
        error: (err: any) => {
          console.log(err);
        }
      })
    }
  }

  imageChanged(event:any) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        const base64 = reader.result?.toString().split(',')[1];
        if (base64) {
          this.movie.imageBase64 = base64;
        }
      }
    }
  }
}
