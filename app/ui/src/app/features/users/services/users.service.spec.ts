import { provideHttpClient } from '@angular/common/http';
import { HttpTestingController, provideHttpClientTesting } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

import { User } from '../models/user.model';
import { UsersService } from './users.service';

describe('UsersService', () => {
  let service: UsersService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UsersService, provideHttpClient(), provideHttpClientTesting()],
    });

    service = TestBed.inject(UsersService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('sends a PUT request when updating a user status', () => {
    const userId = 'c5ef06ae-d22b-46e4-b858-c16490dd7080';
    const expectedUser: User = {
      id: userId,
      name: 'Test User',
      email: 'test@example.com',
      active: false,
    };

    let actualUser: User | undefined;

    service.updateUserStatus(userId, false).subscribe((user) => {
      actualUser = user;
    });

    const request = httpTestingController.expectOne(
      `http://localhost:5258/api/users/${userId}/status`,
    );

    expect(request.request.method).toBe('PUT');
    expect(request.request.body).toEqual({ isActive: false });

    request.flush(expectedUser);

    expect(actualUser).toEqual(expectedUser);
  });
});
