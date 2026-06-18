import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { finalize } from 'rxjs';

import { User } from '../../models/user.model';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'app-users-page',
  imports: [MatButtonModule, MatTableModule],
  templateUrl: './users-page.html',
  styleUrl: './users-page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UsersPage {
  private readonly usersService = inject(UsersService);

  protected readonly displayedColumns = ['name', 'email', 'active', 'actions'];
  protected readonly users = signal<User[]>([]);
  protected readonly loading = signal(true);
  protected readonly errorMessage = signal('');
  protected readonly updatingUserIds = signal<string[]>([]);

  constructor() {
    this.loadUsers();
  }

  protected toggleUserStatus(user: User): void {
    this.errorMessage.set('');
    this.addUpdatingUserId(user.id);

    // The active state is critical, so the UI waits for server confirmation
    // instead of applying an optimistic update that may be wrong.
    this.usersService
      .updateUserStatus(user.id, !user.active)
      .pipe(finalize(() => this.removeUpdatingUserId(user.id)))
      .subscribe({
        next: (updatedUser) => {
          this.users.update((users) =>
            users.map((existingUser) => (existingUser.id === updatedUser.id ? updatedUser : existingUser)),
          );
        },
        error: (error: unknown) => {
          console.error('Failed to update user status.', error);
          this.errorMessage.set(`Unable to update ${user.name}. Please try again.`);
        },
      });
  }

  protected isUpdating(userId: string): boolean {
    return this.updatingUserIds().includes(userId);
  }

  protected getToggleButtonLabel(user: User): string {
    if (this.isUpdating(user.id)) {
      return 'Updating...';
    }

    return user.active ? 'Deactivate' : 'Activate';
  }

  private loadUsers(): void {
    this.loading.set(true);
    this.errorMessage.set('');

    this.usersService.getUsers().subscribe({
      next: (users) => {
        this.users.set(users);
        this.loading.set(false);
      },
      error: (error: unknown) => {
        console.error('Failed to load users.', error);
        this.errorMessage.set('Unable to load users right now. Please refresh and try again.');
        this.loading.set(false);
      },
    });
  }

  private addUpdatingUserId(userId: string): void {
    this.updatingUserIds.update((userIds) =>
      userIds.includes(userId) ? userIds : [...userIds, userId],
    );
  }

  private removeUpdatingUserId(userId: string): void {
    this.updatingUserIds.update((userIds) => userIds.filter((existingUserId) => existingUserId !== userId));
  }
}
