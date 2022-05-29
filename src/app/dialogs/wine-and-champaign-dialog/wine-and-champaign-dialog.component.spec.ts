import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WineAndChampaignDialogComponent } from './wine-and-champaign-dialog.component';

describe('WineAndChampaignDialogComponent', () => {
  let component: WineAndChampaignDialogComponent;
  let fixture: ComponentFixture<WineAndChampaignDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WineAndChampaignDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WineAndChampaignDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
