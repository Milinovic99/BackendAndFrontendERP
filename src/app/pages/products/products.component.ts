import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AllProductsDialogComponent } from 'src/app/dialogs/all-products-dialog/all-products-dialog.component';
import { BeerService } from 'src/app/services/beer.service';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {


  public products:any[]=[];
  public counter:number=0;
  public totalItemInCart:any = 0;
  public Amount:number=1;
  public data:any;
  public p:number=1;

  constructor(public userService:UserService,
              public beerService:BeerService,
              public cartService:CartService,
              public dialog:MatDialog,
              public router:Router) { }

  ngOnInit(): void {
    this.beerService.getProducts('').subscribe(
      res => {
        this.products=res;

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
      this.cartService.AddToCart(item);
      this.cartService.ReceiveAmount(this.Amount);
      }
      else {
        this.router.navigate(['/login']);
      }
  }
  public openDialog(flag: number,product_id?:number,product_name?: string, image_url?: string,liter?: string,price?:number,on_action?:boolean,discout?:string,discount_price?:string,category_id?:number) {
    const dialogRef = this.dialog.open(AllProductsDialogComponent, {data: {product_id,product_name,image_url, liter,price,on_action,discout,discount_price,category_id}});
    dialogRef.componentInstance.flag = flag;
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result === 1) {
          this.ngOnInit();
        }
      });
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

}
