import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User_url } from '../app.constant';
import { Login } from '../models/login';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly LoginUrl='http://localhost:44200/api/korisnici/authenticate';
  readonly UserProfileUrl='http://localhost:44200/api/korisnici/identifyUser';
  public userInformation:any=[];

  constructor(private httpClient: HttpClient) { }

  public getUserById(id:number):Observable<any> {
    return this.httpClient.get(`${User_url}/${id}`);
  }


  public addUser(user:User):Observable<any> {
    return this.httpClient.post(`${User_url}`,user);
  }

  public CheckLogin(formData:Login):Observable<any> {
  return this.httpClient.post(this.LoginUrl,formData);
  }

  public CheckUserProfile(formData:Login):Observable<any> {
    return this.httpClient.post(this.UserProfileUrl,formData);
    }

  loggedIn() {
    return !!localStorage.getItem('token');
  }

  logoutUser() {
    localStorage.removeItem('token');
  }

}
