import { Component, Input, OnInit, Output } from '@angular/core';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  public product:any= [];
  public totalNumber:any = 0;
  public grandTotal :number = 0;
  public counter:number=0;
  public data:any;
  public amount:any[]=[];
  public priceTimesQuantity:any[]=[];



  constructor(private cartService:CartService,
              public userService:UserService) { }

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


  }

  removeAllItems() {
    this.cartService.removeAllCartItems();
  }

  removeItem(item:any) {
    this.cartService.removeCartItem(item);
  }

}
