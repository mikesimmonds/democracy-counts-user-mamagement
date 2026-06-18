# Democracy Counts - user management feature

## Prerequisites
- .NET 10 SDK
- Node.js and npm

## Project structure
This repository contains two separate applications with separate toolchains:
- API: .NET backend under `app/api/`
- Frontend: Angular app under `app/ui/`

There is no root-level command that runs both applications together.

## Running the API
Start the backend from the repository root:

```bash
dotnet run --project app/api/UserManagement.Api/UserManagement.Api.csproj
```

## Running the frontend
Install dependencies and start the Angular development server:

```bash
cd app/ui
npm install
npm start
```

## Running tests
Run backend tests from the repository root:

```bash
dotnet test UserManagement.slnx
```

Run frontend tests from `app/ui`:

```bash
cd app/ui
npm test -- --watch=false
```
