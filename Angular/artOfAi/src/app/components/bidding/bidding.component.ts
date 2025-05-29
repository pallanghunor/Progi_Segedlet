import { Component, EventEmitter, inject, Input, Output, ViewEncapsulation } from '@angular/core';
import { DataService } from '../../services/data.service';
import { FormsModule } from '@angular/forms';
import { PaintingModel } from '../../models/paintingModel';

@Component({
  selector: 'bidding',
  standalone: true,
  imports: [
    FormsModule
  ],
  templateUrl: './bidding.component.html',
  styleUrl: './bidding.component.css',
  encapsulation: ViewEncapsulation.None
})
export class BiddingComponent {
  @Input() painting?: PaintingModel;
  @Output() onSuccessfulBid = new EventEmitter<any>;

  errorMessage: string = '';
  bidData = {
    paintingId: -1,
    email: '',
    price: 0,
    tou: false
  }

  private dataService = inject(DataService);

  save() {
    if (this.validateFields()) {
      this.bidData.paintingId = this.painting?.id!;
      this.dataService.postBid(this.bidData).subscribe({
        next: (result) => {
          alert(result.message)
          this.onSuccessfulBid.emit(this.bidData);
        },
        error: (err) => {
          console.log(err);
          this.errorMessage = err.error.message ?? err.message
        }
      })
    }
  }

  validateFields(): boolean {
    this.errorMessage = '';
    if (!this.bidData?.email) {
      this.errorMessage += 'Please enter your email address!'
      return false;
    }
    if (this.bidData.price! < this.painting!.maxBid!) {
      this.errorMessage += 'Please enter a price larger than the previous bid!'
      return false;
    }
    if (!this.bidData.tou) {
      this.errorMessage += 'Please accept Terms of Use!'
      return false;
    }
    return true;
  }

}
