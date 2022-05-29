import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeDialogComponent } from './coffee-dialog.component';

describe('CoffeeDialogComponent', () => {
  let component: CoffeeDialogComponent;
  let fixture: ComponentFixture<CoffeeDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CoffeeDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
