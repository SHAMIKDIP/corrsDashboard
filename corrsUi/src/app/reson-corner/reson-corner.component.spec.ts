import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResonCornerComponent } from './reson-corner.component';

describe('ResonCornerComponent', () => {
  let component: ResonCornerComponent;
  let fixture: ComponentFixture<ResonCornerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResonCornerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResonCornerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
