import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculadoraCdbComponent } from './calculadora-cdb.component';

describe('CalculadoraCdbComponent', () => {
  let component: CalculadoraCdbComponent;
  let fixture: ComponentFixture<CalculadoraCdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalculadoraCdbComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CalculadoraCdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
