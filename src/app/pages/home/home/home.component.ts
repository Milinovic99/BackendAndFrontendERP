import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  counter:number=0;
  totalItemInCart:any=[];

  constructor(private router:Router,
              public userService:UserService,
              public cartService:CartService,
              public snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.cartService.getProducts().subscribe(res => {
      this.totalItemInCart=res.length;
    })
    if(this.userService.userInformation.purchase_count  == 3)
    this.snackBar.open("Posto ste obavili 3 kupovine,na 2 odabrana proizvoda dobijate 2 gratis!",'U redu', {
      duration: 8000
    })
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
