import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/services/cart.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.css']
})
export class DeliveryComponent implements OnInit {

  displayedColumns=['ID','Destinacija','Cijena_dostave'];
  public totalItemInCart:any = 0;
  data= [{ID:'1',Destinacija:'Telep', Cijena_dostave:'140'},
                {ID:'2',Destinacija:'Adice',Cijena_dostave:'220'},
                {ID:'3',Destinacija:'Salajka',Cijena_dostave:'180'},
                {ID:'4',Destinacija:'Detelinara',Cijena_dostave:'240'},
                {ID:'5',Destinacija:'Grbavica',Cijena_dostave:'210'}
];
  constructor(public userService:UserService,
              public cartService:CartService) { }

  ngOnInit(): void {
    this.cartService.getProducts().subscribe(res => {
      this.totalItemInCart=res.length;
    })
  }

}
