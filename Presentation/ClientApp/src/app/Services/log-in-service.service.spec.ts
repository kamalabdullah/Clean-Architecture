import { TestBed } from '@angular/core/testing';

import { LogInService } from './log-in-service.service';

describe('LogInServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LogInService = TestBed.get(LogInService);
    expect(service).toBeTruthy();
  });
});
