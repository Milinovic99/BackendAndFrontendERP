import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { CartService } from 'src/app/services/cart.service';
import { StripeService } from 'src/app/services/stripe.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-delivery-data',
  templateUrl: './delivery-data.component.html',
  styleUrls: ['./delivery-data.component.css']
})
export class DeliveryDataComponent implements OnInit {

  public product:any=[];
  checkoutButton:any=[];
  public totalNumber:any = 0;
 sessionValue:any=[];
  public totalItemInCart:number=0;
  public grandTotal :number = 0;
  public priceTimesQuantity:any[]=[];
  public amount:any[]=[];

  public ArrayTotal:any={};

  constructor(private router:Router,
    public userService:UserService,
    private cartService:CartService,
    public stripeService:StripeService) { }

  ngOnInit(): void {
    this.cartService.getProducts().subscribe((res) => {
      this.totalNumber=res.length;
      this.product=res;
      this.grandTotal=this.cartService.getTotalPrice();
    })
    this.cartService.getQuantites().subscribe((res)=> {
      this.amount=res;
    })
    this.priceTimesQuantity=this.cartService.PriceList;


    if(this.product.length!=0) {

    //  this.ArrayTotal={
     //  product: this.product,
      // amount:this.amount
      //}

   this.stripeService.OpenStripeCheckout(this.product).subscribe((res)=> {
    this.sessionValue=res;
    console.log(this.sessionValue.id);
});
    }

    this.cartService.getProducts().subscribe(res => {
      this.totalItemInCart=res.length;
    })
  }


  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }


  checkoutButtons(value:string) {
    var stripe = Stripe('pk_test_51L0AFMH4loDMFXfK7dGGxk0KrNraQDFfVoVMxOi0cIrHElLcCVOqmAFphREpCpAoZG7Q7QOBnaqob5DaFR3mpSAo0088gHjszB');
    this.checkoutButton = document.getElementById('checkout-button');
  //  console.log(value);
    this.checkoutButton.addEventListener('click', function() {
      stripe.redirectToCheckout({
        // Make the id field from the Checkout Session creation API response
        // available to this file, so you can provide it as argument here
        // instead of the {{CHECKOUT_SESSION_ID}} placeholder.
        sessionId: value
      }).then(function (result) {
        // If `redirectToCheckout` fails due to a browser or network
        // error, display the localized error message to your customer
        // using `result.error.message`.
      });
    });
  }



}
