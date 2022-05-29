import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BeerService } from 'src/app/services/beer.service';

@Component({
  selector: 'app-coffee-dialog',
  templateUrl: './coffee-dialog.component.html',
  styleUrls: ['./coffee-dialog.component.css']
})
export class CoffeeDialogComponent implements OnInit {

  public flag:number;
  constructor(public snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<CoffeeDialogComponent>,
    public beerService:BeerService,
    @Inject (MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  public add(): void {
    this.beerService.AddProducts(this.data)
      .subscribe(() => {
        this.snackBar.open('Uspijesno dodan proizvod: ' + this.data.product_id , 'U redu', {
          duration: 2500
        });
      }),
      // tslint:disable-next-line: no-unused-expression
      (error: Error) => {
        console.log(error.name + '-->' + error.message);
        this.snackBar.open('Dogodila se greska. Pokusajte ponovo!', 'Zatvori', {
          duration: 2500
        });
      };
  }

  public update(): void {
    this.beerService.updateProduct(this.data)
      .subscribe(() => {
        this.snackBar.open('Uspijesno modifikovan proizvod: ' + this.data.product_id , 'U redu', {
          duration: 2500
        });
      }),
      // tslint:disable-next-line: no-unused-expression
      (error: Error) => {
        console.log(error.name + '-->' + error.message);
        this.snackBar.open('Dogodila se greska. Pokusajte ponovo!', 'Zatvori', {
          duration: 2500
        });
      };
  }

  public delete(): void {
    this.beerService.deleteProduct(this.data.product_id)
      .subscribe(() => {
        this.snackBar.open('Uspijesno obrisan proizvod', + this.data.product_id + 'U redu', {
          duration: 2500
        });
      }),
      // tslint:disable-next-line: no-unused-expression
      (error: Error) => {
        console.log(error.name + '-->' + error.message);
        this.snackBar.open('Dogodila se greska. Pokusajte ponovo!', 'Zatvori', {
          duration: 2500
        });
      };
  }

  public cancel(): void {
    this.dialogRef.close();
    this.snackBar.open('Odustali ste od izmena!', 'U redu', {
      duration: 1000
    });
  }
}
