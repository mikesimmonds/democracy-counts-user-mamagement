import { Routes } from '@angular/router';

import { UsersPage } from './features/users/pages/users-page/users-page';

export const routes: Routes = [
  {
    path: 'users',
    component: UsersPage,
  },
  {
    path: '**',
    redirectTo: "users"
  }
];
