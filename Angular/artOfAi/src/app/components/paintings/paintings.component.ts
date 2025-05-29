import { Component, inject, ViewEncapsulation } from '@angular/core';
import { DataService } from '../../services/data.service';
import { PaintingModel } from '../../models/paintingModel';
import { CategoryModel } from '../../models/categoryModel';
import { BiddingComponent } from "../bidding/bidding.component";

@Component({
  selector: 'app-paintings',
  standalone: true,
  imports: [BiddingComponent],
  templateUrl: './paintings.component.html',
  styleUrl: './paintings.component.css',
  encapsulation: ViewEncapsulation.None
})
export class PaintingsComponent {
  private dataService = inject(DataService);

  paintings: PaintingModel[] = [];
  categories: CategoryModel[] = [];
  bids: any[] = [];
  bidData: PaintingModel | null = null;

  ngOnInit() {
    this.dataService.getCategories().subscribe({
      next: (result) => this.categories = result,
      error: (err) => console.log(err)
    });
    this.fetchPaintings(event = { target: { value: '' } } as any);
  }

  fetchPaintings(event: any) {
    this.dataService.getPaintings(event.target.value).subscribe({
      next: (result) => this.paintings = result,
      error: (err) => console.log(err)
    });
  }

  fetchBids(_paintingId: number | string) {
    this.dataService.getBids(_paintingId).subscribe({
      next: (result) => this.bids = result,
      error: (err) => console.log(err)
    })
  }

  placeBid(_painting: PaintingModel) {
    this.bidData = _painting;
  }

  sendBid(_event: any){
    const painting = this.paintings.filter(p => p.id == this.bidData?.id)[0];
    painting.numberOfBids++;
    painting.maxBid = _event.price;

    this.bidData = null;
  }
}
