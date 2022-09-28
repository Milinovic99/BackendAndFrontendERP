import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/services/cart.service';
import { StripeService } from 'src/app/services/stripe.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  data:any=[];

  constructor(public stripeService:StripeService,
              public userService:UserService,
              public cartService:CartService) { }

  totalItemInCart:any=[];

  ngOnInit(): void {
    this.stripeService.getPayments().subscribe((res)=> {
      this.data=res;
    })
    this.cartService.getProducts().subscribe(res => {
      this.totalItemInCart=res.length;
    }),
      (err:Error) => {
        console.log(err.name+err.message);
    }

  }

  removePayment(item:number) {
    this.stripeService.deletePayment(item);
  }

}
