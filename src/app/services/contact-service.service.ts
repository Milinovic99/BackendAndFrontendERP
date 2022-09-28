import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact_url } from '../app.constant';
import { Contact } from '../models/contact';


@Injectable({
  providedIn: 'root'
})
export class ContactServiceService {



  constructor(private httpClient: HttpClient ) { }

  public getAllContact(): Observable<any> {
    return this.httpClient.get(`${Contact_url}`);
  }

  public addContact(contact:Contact): Observable<any> {
    return this.httpClient.post(`${Contact_url}`,contact);
  }
}
