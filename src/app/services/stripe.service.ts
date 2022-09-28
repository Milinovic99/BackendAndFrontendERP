import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StripeService {

 readonly baseUrl='http://localhost:44200/create-checkout-session';
 readonly PaymentUrl='http://localhost:44200/api/placanje';

 StripeInformation:any=[];

  constructor(private httpClient:HttpClient) { }

public OpenStripeCheckout(product:any):Observable<any> {
return this.httpClient.post(this.baseUrl,product);
}

public getPayments():Observable<any> {
  return this.httpClient.get(this.PaymentUrl);
}

public deletePayment(id: number): Observable<any> {
  return this.httpClient.delete(`${this.PaymentUrl}/${id}`);
}


}


