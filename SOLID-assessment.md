# SOLID Assessment

This test application shows SOLID principles in the way it is built. 
However the frontend code shows significantly less SOLID principles - so this document will focus on the backend.

I would say this is a pragmatic approach to SOLID principles, rather than very strict.

## Single Responsibility Principle

- UsersController handles HTTP concerns, `UserService` holds business rules, and `UserRepository` handles persistence .
- One example of thisis the "admin cannot be disabled" rule living in the service layer rather than the controller or repository.
- The controller still contains DTO mapping logic. This would not usually be the case. I have used AutoMapper in general.
- The Angular app is no such a good example `UsersPage` owns fetching, error handling, loading state, and update interactions. This should be far better organised, but time constraints simply didn't allow it.

## Open/Closed Principle

- The backend is partly open for extension because the controller depends on `IUserService` and the service depends on `IUserRepository`, so implementations can be replaced without changing consuming code.
- As the app is small still, its unlikely that the implementation would really closed, but it is there conceptually.

## (Barbara) Liskov Substitution Principle

- The code supports LSP in a straightforward way: `UserService` and `UserRepository` are used throughnthier interfaces: `IUserService` and `IUserRepository`.
- The service test also reinforces this by substituting the repository dependency without changing service behaviour.

## Interface Segregation Principle

- ISP is only lightly demonstrated. The interfaces are small, which is good, but they are still broad enough that consumers take the whole contract rather than very narrow task-specific interfaces.
- The frontend does not really apply ISP because components depend directly on concrete services rather than narrower contracts.
  - I'm used to a large amount of frontend churn in my previous roles - however I do understand that ISP is doable in TS.

## Dependency Inversion Principle

- Dotnet handles a lot of this for you
- DI is the clearest SOLID success in this codebase. High-level policy depends on abstractions: the controller depends on `IUserService`, the service depends on `IUserRepository`, and `Program.cs` wires those abstractions to concrete types through DI.