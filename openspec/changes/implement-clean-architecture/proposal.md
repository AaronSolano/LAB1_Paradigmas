## Why

The current single-project structure has basic folder separation, but Application services directly access the DbContext, coupling application logic to EF Core persistence. Refactoring to Clean Architecture enforces the Dependency Inversion Principle, isolating pure Domain entities, defining repository interfaces in Application, implementing data access in Infrastructure, and keeping HTTP handling in Presentation.

## What Changes

- Reorganize the solution into strict Clean Architecture layers:
  - **Domain**: Pure domain entities (`Book`, `Library`) and core interfaces without framework dependencies (`LibraryService.WebAPI.Domain.Entities`).
  - **Application**: Use cases and application services (`BooksService`, `LibrariesService`), DTOs (`BookForm`, `LibraryForm`), and repository contracts (`IBookRepository`, `ILibraryRepository`) under `LibraryService.WebAPI.Application`.
  - **Infrastructure**: Persistence implementation with `LibraryContext` (EF Core / Supabase PostgreSQL) and concrete repositories (`BookRepository`, `LibraryRepository`) under `LibraryService.WebAPI.Infrastructure`.
  - **Presentation**: Web API controllers (`BooksController`, `LibrariesController`) and DI service registrations (`LibraryService.WebAPI.Presentation`).
- Enforce Dependency Inversion Principle: controllers depend on application service interfaces, application services depend on repository interfaces, and infrastructure implements those repository interfaces.
- Preserve existing REST API contracts, routes, and JSON schemas.

## Capabilities

### New Capabilities

- `library-service`: Manages libraries and books using Clean Architecture with strict Dependency Inversion and repository abstractions across Presentation, Application, Domain, and Infrastructure layers.

### Modified Capabilities

None.

## Impact

- Affected namespaces and files: `Domain/*`, `Application/*`, `Infrastructure/*`, `Infrastructure/Repositories/*`, `Presentation/*`, `Startup.cs`.
- Test projects: `LibraryService.Integration.Test` usings updated to reference the new repository/layer namespaces.
- Dependencies: Unchanged.
