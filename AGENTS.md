# Repository Notes

- This repo has two separate apps with separate toolchains; there is no root build runner.
- Backend: `.NET` solution at `UserManagement.slnx` with projects under `app/api/`.
- Frontend: Angular app under `app/ui/` with its own `package.json` and its own nested `app/ui/AGENTS.md`. Follow that file for Angular-specific conventions.

## Commands

- Backend test all: `dotnet test UserManagement.slnx`
- Backend test single project: `dotnet test app/api/UserManagement.Tests/UserManagement.Tests.csproj`
- Run API: `dotnet run --project app/api/UserManagement.Api/UserManagement.Api.csproj`
- Frontend install: `npm install` in `app/ui`
- Frontend dev server: `npm start` in `app/ui`
- Frontend build: `npm run build` in `app/ui`
- Frontend tests once: `npm test -- --watch=false` in `app/ui`
- Do not use `npm test -- --run`; `ng test` here rejects `--run`.

## Verified Structure

- `app/ui/src/main.ts` bootstraps a standalone Angular app from `src/app/app.ts`.
- `app/ui/src/app/app.routes.ts` is currently empty.
- `app/ui/src/app/app.html` is still the default Angular starter template, and `app/ui/src/app/app.spec.ts` still asserts `Hello, ui`.
- `app/api/UserManagement.Api/Program.cs` is still the default minimal startup: controllers + OpenAPI only.
- `app/api/UserManagement.Api/Controllers/`, `Data/`, `DTOs/`, and `Repositories/` currently exist but are empty.
- `app/api/UserManagement.Domain/Models/User.cs` is the only non-generated backend domain file with real model content; `Class1.cs` and `UserManagement.Tests/UnitTest1.cs` are still placeholders.

## Tooling Facts

- Angular build config is in `app/ui/angular.json`; `ng build` defaults to the `production` configuration, while `ng serve` defaults to `development`.
- Angular uses SCSS (`inlineStyleLanguage: scss`) and serves static assets from `app/ui/public/`.
- Frontend TypeScript and Angular template strictness are enabled in `app/ui/tsconfig.json`.
- Frontend formatting is Prettier with `singleQuote: true` and `printWidth: 100`; `.editorconfig` sets 2-space indentation.
- Backend targets `net10.0`; tests use NUnit with NSubstitute.

## Gotchas

- The repo includes generated folders such as `app/ui/node_modules/` and `.NET` `bin/`/`obj/`; avoid treating those as source.
- `dotnet test UserManagement.slnx` currently passes, but it emits a nullable warning from `app/api/UserManagement.Domain/Models/User.cs` because `Roles` is not initialized.
- There are no root CI workflows, lint configs, or workspace-level task runners to rely on; use the package/project-local commands above.
