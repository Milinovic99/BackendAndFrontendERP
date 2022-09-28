import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RatingService } from 'src/app/services/rating.service';

@Component({
  selector: 'app-rating-dialog',
  templateUrl: './rating-dialog.component.html',
  styleUrls: ['./rating-dialog.component.css']
})
export class RatingDialogComponent implements OnInit {

  public flag:number;
  constructor(public snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<RatingDialogComponent>,
    public ratingService:RatingService,
    @Inject (MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {
  }

  public add(): void {
    this.ratingService.AddRating(this.data)
      .subscribe(() => {
        this.snackBar.open('Uspijesno dodana ocjena!' , 'U redu', {
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
    this.snackBar.open('Odustali ste od ocjenjivanja!', 'U redu', {
      duration: 1000
    });
  }
}
