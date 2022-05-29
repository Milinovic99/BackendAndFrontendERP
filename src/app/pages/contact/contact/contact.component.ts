import { Component, Inject, Input, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Contact } from 'src/app/models/contact';
import { CartService } from 'src/app/services/cart.service';
import { ContactServiceService } from 'src/app/services/contact-service.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

   data = new Contact();
   public totalItemInCart:any=[];


  constructor(private contactService:ContactServiceService,
               public snackBar:MatSnackBar ,
               public userService:UserService,
               public cartService:CartService ) { }

  ngOnInit(): void {
    this.cartService.getProducts().subscribe(res => {
      this.totalItemInCart=res.length;
    })
  }

   addCont(): void {
    this.contactService.addContact(this.data).subscribe(
        (res) => {
           console.log(res);
           this.snackBar.open("Uspjesno ste poslali poruku",'U redu');
        }),
       (err:Error) => {
          console.log(err.name + " " + err.message);

    }
  }

}
