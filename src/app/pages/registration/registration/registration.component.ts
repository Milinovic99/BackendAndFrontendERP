import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { User } from 'src/app/models/user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

    data=new User();
    public message:string='';


  constructor(private userService: UserService,
              public snackBar: MatSnackBar,
              ) { }

  ngOnInit(): void {
  }

    public add():void {
  this.userService.addUser(this.data).subscribe(
      (res) => {
        console.log(res);
        this.snackBar.open("Uspjesno ste se registrovali",'U redu');
      }),
     (err:HttpErrorResponse) => {
       console.log(err.error.message);
       this.snackBar.open("Doslo je do greske!",'Zatvori');
    }


    }



}
