import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent } from '@angular/material/paginator';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ActionDialogComponent } from 'src/app/dialogs/action-dialog/action-dialog.component';
import { RatingDialogComponent } from 'src/app/dialogs/rating-dialog/rating-dialog.component';
import { BeerService } from 'src/app/services/beer.service';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-actions',
  templateUrl: './actions.component.html',
  styleUrls: ['./actions.component.css']
})
export class ActionsComponent implements OnInit {

  public products:any[]=[];
  public totalItemInCart:any = 0;
  public data:any;
  public Amount:any=1;
  public p:number=1;
  public counter:number=0;
  sub:Subscription;


  constructor(public userService:UserService,
    public beerService:BeerService,
    public cartService:CartService,
    public dialog:MatDialog,
    public router:Router) { }

  ngOnInit(): void {
  this.sub=this.beerService.getProducts('').subscribe(
  res => {
    for(let i=0; i<res.length; i++) {
      if(res[i].on_action == true) {
        this.products[this.counter++]=res[i];
      }
    }

  this.products.forEach((a:any) => {
  Object.assign(a,{total:a.price});
  });
  }),
(err:Error) => {
console.log(err.name + err.message);
}
this.cartService.getProducts().subscribe(res => {
this.totalItemInCart=res.length;
})
}

AddToCart(item:any) {
  if(this.userService.loggedIn()) {
    if(this.userService.userInformation.purchase_count % 3 == 0 && this.totalItemInCart<2) {
      this.Amount=this.Amount + 1;
    }
    this.cartService.AddToCart(item);
    this.cartService.ReceiveAmount(this.Amount);
    }
    else {
      this.router.navigate(['/login']);
    }
}


SortAsc() {
let newArr =this.products.sort((a:any, b:any) => {
  if(a.on_action!=false && b.on_action!=false) {
    return a.discount_price - b.discount_price;
    }
   else if (a.on_action!=false){
        return a.discount_price-b.price;
    }
    else if (b.on_action!=false) {
      return a.price-b.discount_price;
    }
    else {
      return a.price-b.price;
    }

});
this.products=newArr;
}
SortDesc() {
let NewArr=this.products.sort((a:any,b:any)=> {
  if(a.on_action!=false && b.on_action!=false) {
    return b.discount_price - a.discount_price;
    }
   else if (a.on_action!=false){
        return b.price-a.discount_price;
    }
    else if (b.on_action!=false) {
      return b.discount_price-a.price;
    }
    else {
      return b.price-a.price;
    }
});
this.products=NewArr;
}


SortDescName() {
this.products.sort((a:any,b:any) => {
if(a.product_name<b.product_name)
return -1;
else
return -1;
});

}
SortAscName() {
this.products.sort((a:any,b:any)=> {
if(a.product_name>b.product_name)
return 1;
else
return -1;
});

}
public openDialog(flag: number,product_id?:number,product_name?: string, image_url?: string,liter?: string,price?:number,on_action?:boolean,discout?:string,discount_price?:string,category_id?:number) {
  const dialogRef = this.dialog.open(ActionDialogComponent, {data: {product_id,product_name,image_url, liter,price,on_action,discout,discount_price,category_id}});
  dialogRef.componentInstance.flag = flag;
  dialogRef.afterClosed()
    .subscribe(result => {
      if (result === 1) {
        this.ngOnInit();
      }
    });
  }
  public openRatingDialog(product_id?:number,user_id?: number) {
    const dialogRef = this.dialog.open(RatingDialogComponent, {data: {product_id,user_id}});
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result === 1) {
          this.ngOnInit();
        }
      });
    }
}
