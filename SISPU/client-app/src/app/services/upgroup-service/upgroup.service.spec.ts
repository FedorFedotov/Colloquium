import { TestBed, inject } from '@angular/core/testing';

import { UpgroupService } from './upgroup.service';

describe('UpgroupService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UpgroupService]
    });
  });

  it('should be created', inject([UpgroupService], (service: UpgroupService) => {
    expect(service).toBeTruthy();
  }));
});
