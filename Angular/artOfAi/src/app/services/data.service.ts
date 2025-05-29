import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryModel } from '../models/categoryModel';
import { PaintingModel } from '../models/paintingModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private http = inject(HttpClient);

  constructor() { }

  apiUrl: string = 'https://art-of-ai-auction.jedlik.cloud/api'

  getCategories(): Observable<CategoryModel[]> {
    return this.http.get<CategoryModel[]>(`${this.apiUrl}/categories`);
  }

  getPaintings(_categoryId: string | number): Observable<PaintingModel[]> {
    return this.http.get<PaintingModel[]>(`${this.apiUrl}/paintings/${_categoryId}`);
  }

  getBids(_paintingId: string | number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/bids/${_paintingId}`);
  }

  postBid(_data: any): Observable<{ message: string }> {
    return this.http.post<any>(`${this.apiUrl}/bid`, _data);
  }
}
