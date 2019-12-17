import { TestBed } from '@angular/core/testing';

import { BeerTypeService } from './beer-type.service';

describe('BeerTypeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BeerTypeService = TestBed.get(BeerTypeService);
    expect(service).toBeTruthy();
  });
});
