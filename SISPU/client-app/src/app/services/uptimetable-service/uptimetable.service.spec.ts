import { TestBed, inject } from '@angular/core/testing';

import { UptimetableService } from './uptimetable.service';

describe('UptimetableService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UptimetableService]
    });
  });

  it('should be created', inject([UptimetableService], (service: UptimetableService) => {
    expect(service).toBeTruthy();
  }));
});


