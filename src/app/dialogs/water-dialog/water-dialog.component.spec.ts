import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WaterDialogComponent } from './water-dialog.component';

describe('WaterDialogComponent', () => {
  let component: WaterDialogComponent;
  let fixture: ComponentFixture<WaterDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WaterDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WaterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
