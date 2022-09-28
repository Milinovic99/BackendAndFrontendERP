import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotChocolateComponent } from './hot-chocolate.component';

describe('HotChocolateComponent', () => {
  let component: HotChocolateComponent;
  let fixture: ComponentFixture<HotChocolateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HotChocolateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HotChocolateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
