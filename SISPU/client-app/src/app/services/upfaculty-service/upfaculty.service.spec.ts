import { TestBed, inject } from '@angular/core/testing';

import { UpfacultyService } from './upfaculty.service';

describe('UpfacultyService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UpfacultyService]
    });
  });

  it('should be created', inject([UpfacultyService], (service: UpfacultyService) => {
    expect(service).toBeTruthy();
  }));
});
