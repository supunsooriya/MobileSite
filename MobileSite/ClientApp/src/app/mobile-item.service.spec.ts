import { TestBed, inject } from '@angular/core/testing';

import { MobileItemService } from './mobile-item.service';

describe('MobileItemService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MobileItemService]
    });
  });

  it('should be created', inject([MobileItemService], (service: MobileItemService) => {
    expect(service).toBeTruthy();
  }));
});
