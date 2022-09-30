import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cardItemList:any = [];
  public quantity:any='';
  public PriceList:any[]=[];
  public quantityList:any[]=[];
  public quantiyBehaviourSubject=new BehaviorSubject<any>([]);
  public productList = new BehaviorSubject<any>([]);

  constructor() { }

  getProducts() {
    return this.productList.asObservable();
  }
  getQuantites() {
    return this.quantiyBehaviourSubject.asObservable();
  }

setProduct(product:any) {
  this.cardItemList.push(...product);
  this.productList.next(product);
}

ReceiveAmount(amount:number) {
  this.quantity=amount;
this.quantityList.push(this.quantity);
this.quantiyBehaviourSubject.next(this.quantityList);
}

AddToCart(product:any) {
  this.cardItemList.push(product);
  this.productList.next(this.cardItemList);
  this.getTotalPrice();

}


getTotalPrice() :number {
  let grandTotal=0;
  let i=0;
  this.cardItemList.map((a:any) => {
    if(a.on_action!=false) {
    this.PriceList[i]=a.discount_price*this.quantityList[i];
    grandTotal+=a.discount_price*this.quantityList[i++];
    }
    else {
      this.PriceList[i]=a.price*this.quantityList[i];
      grandTotal+=a.price*this.quantityList[i++];
    }
  })
  return grandTotal;
}


removeCartItem(product:any) {
  this.cardItemList.map((a:any,index:any) => {
    if(product.product_id === a.product_id) {
      this.cardItemList.splice(index,1);
      this.quantityList.splice(index,1);
    }
  })
  this.productList.next(this.cardItemList);
  this.quantiyBehaviourSubject.next(this.quantityList);
}

removeAllCartItems() {
  this.cardItemList=[];
  this.productList.next(this.cardItemList);
  this.quantityList=[];
  this.quantiyBehaviourSubject.next(this.quantityList);
  this.PriceList=[];
}

}
