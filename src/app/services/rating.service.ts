import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rating_url } from '../app.constant';

@Injectable({
  providedIn: 'root'
})
export class RatingService {

  constructor(private http:HttpClient) { }

  public AddRating(rating:any):Observable<any> {
    rating.rating_id=0;
     return this.http.post(`${Rating_url}`, rating)
   }

}
