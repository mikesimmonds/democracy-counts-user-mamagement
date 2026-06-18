import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

import { userApi } from '../../../core/api/user.api';
import { UpdateUserStatusRequest } from '../models/update-user-status-request.model';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private readonly http = inject(HttpClient);

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(userApi.getAllUsers);
  }

  getActiveUsers(): Observable<User[]> {
    return this.http.get<User[]>(userApi.getActiveUsers);
  }

  updateUserStatus(userId: string, active: boolean): Observable<User> {
    const request: UpdateUserStatusRequest = { isActive: active };

    return this.http.put<User>(userApi.updateUserStatus(userId), request);
  }
}
