import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeaDialogComponent } from './tea-dialog.component';

describe('TeaDialogComponent', () => {
  let component: TeaDialogComponent;
  let fixture: ComponentFixture<TeaDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeaDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeaDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
