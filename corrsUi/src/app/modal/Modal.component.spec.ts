import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonModal } from './Modal';

describe('CommonModal', () => {
  let component: CommonModal;
  let fixture: ComponentFixture<CommonModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommonModal ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommonModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
