import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnergeticDrinkDialogComponent } from './energetic-drink-dialog.component';

describe('EnergeticDrinkDialogComponent', () => {
  let component: EnergeticDrinkDialogComponent;
  let fixture: ComponentFixture<EnergeticDrinkDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnergeticDrinkDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EnergeticDrinkDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
