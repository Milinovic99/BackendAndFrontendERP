import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarbonatedJuicesComponent } from './carbonated-juices.component';

describe('CarbonatedJuicesComponent', () => {
  let component: CarbonatedJuicesComponent;
  let fixture: ComponentFixture<CarbonatedJuicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CarbonatedJuicesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CarbonatedJuicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
