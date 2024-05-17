import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
  platinumCount: number = 0;
  goldCount: number = 0;
  silverCount: number = 0;
  totalTickets: number = 0;
  totalPrice: number = 0;

  constructor(
    private route : Router
  ){}

  increment(type: string) {
    if (type === 'platinum') {
      this.platinumCount++;
    } else if (type === 'gold') {
      this.goldCount++;
    } else if (type === 'silver') {
      this.silverCount++;
    }
    this.updateTotal();
  }

  decrement(type: string) {
    if (type === 'platinum' && this.platinumCount > 0) {
      this.platinumCount--;
    } else if (type === 'gold' && this.goldCount > 0) {
      this.goldCount--;
    } else if (type === 'silver' && this.silverCount > 0) {
      this.silverCount--;
    }
    this.updateTotal();
  }

  updateTotal() {
    this.totalTickets = this.platinumCount + this.goldCount + this.silverCount;
    this.totalPrice = this.platinumCount * 100 + this.goldCount * 80 + this.silverCount * 60;
  }

  downloadPDF(){
    this.route.navigate(['/confirmation']);
  }
}
