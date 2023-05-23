import { TestBed } from '@angular/core/testing';

import { CalculadoraCdbService } from './calculadora-cdb.service';

describe('CalculadoraCdbService', () => {
  let service: CalculadoraCdbService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculadoraCdbService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
