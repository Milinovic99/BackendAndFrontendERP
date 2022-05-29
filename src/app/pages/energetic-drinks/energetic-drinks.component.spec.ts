import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnergeticDrinksComponent } from './energetic-drinks.component';

describe('EnergeticDrinksComponent', () => {
  let component: EnergeticDrinksComponent;
  let fixture: ComponentFixture<EnergeticDrinksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnergeticDrinksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EnergeticDrinksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
