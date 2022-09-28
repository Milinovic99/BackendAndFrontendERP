import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WineAndChampaignComponent } from './wine-and-champaign.component';

describe('WineAndChampaignComponent', () => {
  let component: WineAndChampaignComponent;
  let fixture: ComponentFixture<WineAndChampaignComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WineAndChampaignComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WineAndChampaignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
