import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product_url } from '../app.constant';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class BeerService {

  constructor(private http:HttpClient) { }

  public getProducts(item:string):Observable<any> {
    return this.http.get(`${Product_url}/${item}`);
  }

  public AddProducts(product:any):Observable<any> {
   product.product_id=0;
    product.on_action = product.on_action == 'true' ? true: false
    return this.http.post(`${Product_url}`, product)
  }

  public updateProduct(product: any): Observable<any> {
    return this.http.put(`${Product_url}`, product);
  }

  public deleteProduct(id: number): Observable<any> {
    return this.http.delete(`${Product_url}/${id}`);
  }

}
