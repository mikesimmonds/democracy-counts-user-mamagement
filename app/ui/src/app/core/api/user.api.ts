const usersBaseUrl = 'http://localhost:5258/api/users';

export const userApi = {
  getAllUsers: usersBaseUrl,
  getActiveUsers: `${usersBaseUrl}/active`,
  updateUserStatus: (id: string) => `${usersBaseUrl}/${id}/status`,
} as const;
