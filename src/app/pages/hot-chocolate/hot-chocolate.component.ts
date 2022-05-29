import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Subscription } from 'rxjs';
import { BeerService } from 'src/app/services/beer.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-hot-chocolate',
  templateUrl: './hot-chocolate.component.html',
  styleUrls: ['./hot-chocolate.component.css']
})
export class HotChocolateComponent implements OnInit {

  public products:any;
  public isDesc:boolean=false;
  public data:any;
  public pageSlice:any;
  sub:Subscription;

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;



  constructor(public userService:UserService,
              public beerService:BeerService) { }

  ngOnInit(): void {
    this.sub=this.beerService.getProducts('').subscribe(
      res => {
        this.products=res;
        this.pageSlice=this.products.slice(0,6);
      }),
      (err:Error) => {
        console.log(err.name + err.message);
      }
  }

  OnPageChange(event:PageEvent) {
    const startIndex=event.pageIndex * event.pageSize;
    let endIndex=startIndex + event.pageSize;
    if(endIndex>this.products.length) {
    endIndex=this.products.length;
    }
    this.pageSlice=this.products.slice(startIndex,endIndex);
  }

  SortAsc() {
    let newArr =this.pageSlice.sort((a:any, b:any) => {
      return a.price - b.price;

    });
   this.pageSlice=newArr;
  }
  SortDesc() {
    let NewArr=this.pageSlice.sort((a:any,b:any)=> {
      return b.price-a.price
    });
    this.pageSlice=NewArr;
  }


  SortDescName() {
    this.pageSlice.sort((a:any,b:any) => {
    if(a.product_name<b.product_name)
    return -1;
    else
    return -1;
    });

  }
  SortAscName() {
    this.pageSlice.sort((a:any,b:any)=> {
      if(a.product_name>b.product_name)
    return 1;
    else
    return -1;
    });

  }




}
