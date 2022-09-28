import { Component, Inject, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-profiles',
  templateUrl: './user-profiles.component.html',
  styleUrls: ['./user-profiles.component.css']
})
export class UserProfilesComponent implements OnInit {

data:any = [];
RoleMessage:string='';
totalItemInCart:any=[];


  constructor(private router:Router,
             public userService:UserService,
             public cartService:CartService) { }

  ngOnInit(): void {
   this.data=this.userService.userInformation;
    console.log(this.data);
    if(this.data.role_id == 1) {
    this.RoleMessage='Administator';
    }
    if(this.data.role_id == 2)
    this.RoleMessage='Korisnik';

    this.cartService.getProducts().subscribe(res => {
      this.totalItemInCart=res.length;
    })
  }


  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
