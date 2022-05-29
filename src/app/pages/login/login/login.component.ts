import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

data=new Login();

  constructor(public userService:UserService,
              private router:Router) { }

  ngOnInit(): void {
  }


  checkEmailAndPass():void {
    this.userService.CheckLogin(this.data).subscribe(
      (res)=>
      {
       this.userService.userInformation=res.user;
       console.log(res.token);
      localStorage.setItem('token',res.token);
      this.router.navigateByUrl('/home');
      }
    ),
    (error:Error) =>{
      console.log("Netacan email ili lozinka!");
    }
  }

}
