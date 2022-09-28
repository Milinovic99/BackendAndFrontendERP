import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JuiceDialogComponent } from './juice-dialog.component';

describe('JuiceDialogComponent', () => {
  let component: JuiceDialogComponent;
  let fixture: ComponentFixture<JuiceDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JuiceDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JuiceDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
