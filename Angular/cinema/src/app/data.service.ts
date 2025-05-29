import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieModel } from './movie.model';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  apiUrl='https://cinema.jedlik.cloud/api';
  

  getMovies(): Observable<MovieModel[]> {
    return this.http.get<MovieModel[]>(`${this.apiUrl}/movie`);
  }

  postMovie(model: MovieModel): Observable<MovieModel> {
    return this.http.post<MovieModel>(`${this.apiUrl}/movie`, model);
  }

  putMovie(model: MovieModel): Observable<MovieModel> {
    return this.http.put<MovieModel>(`${this.apiUrl}/movie/${model.id}`, model);
  }

  deleteMovie(id: Number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/movie/${id}`);
  }
}
