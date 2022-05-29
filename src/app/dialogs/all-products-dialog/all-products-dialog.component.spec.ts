import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllProductsDialogComponent } from './all-products-dialog.component';

describe('AllProductsDialogComponent', () => {
  let component: AllProductsDialogComponent;
  let fixture: ComponentFixture<AllProductsDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllProductsDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllProductsDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
