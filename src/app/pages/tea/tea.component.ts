import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { TeaDialogComponent } from 'src/app/dialogs/tea-dialog/tea-dialog.component';
import { BeerService } from 'src/app/services/beer.service';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-tea',
  templateUrl: './tea.component.html',
  styleUrls: ['./tea.component.css']
})
export class TeaComponent implements OnInit {

  public products:any[]=[];
  public isDesc:boolean=false;
  public data:any;
  public Amount:any=1;
  public p:number=1;
  public totalItemInCart:number=0;
  public counter:number=0;
  sub:Subscription;




  constructor(public userService:UserService,
              public beerService:BeerService,
              public dialog:MatDialog,
              public cartService:CartService,
              public router:Router) { }

  ngOnInit(): void {
    this.beerService.getProducts('').subscribe(
      res => {
        for(let i=0; i<res.length; i++) {
          if(res[i].category_id == 3) {
            this.products[this.counter++]=res[i];
          }
        }
        this.cartService.getProducts().subscribe(res => {
          this.totalItemInCart=res.length;
        })

        this.products.forEach((a:any) => {
          Object.assign(a,{total:a.price});
        });

      }),
      (err:Error) => {
        console.log(err.name + err.message);
      }
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
    const dialogRef = this.dialog.open(TeaDialogComponent, {data: {product_id,product_name,image_url, liter,price,on_action,discout,discount_price,category_id}});
    dialogRef.componentInstance.flag = flag;
    dialogRef.afterClosed()
      .subscribe(result => {
        if (result === 1) {
          this.ngOnInit();
        }
      });
    }




}
