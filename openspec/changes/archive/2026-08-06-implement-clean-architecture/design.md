## Context

Currently, `BooksService` and `LibrariesService` depend directly on `LibraryContext` (EF Core / Supabase persistence). Clean Architecture requires that application services depend on abstractions (Repository interfaces) defined in the Application layer rather than concrete DbContext infrastructure.

## Goals / Non-Goals

**Goals:**
- Introduce `ILibraryRepository` and `IBookRepository` interfaces in `Application/Interfaces/Repositories/`.
- Implement `LibraryRepository` and `BookRepository` in `Infrastructure/Repositories/` wrapping `LibraryContext`.
- Update `LibrariesService` and `BooksService` in `Application/Services/` to inject and use repository interfaces instead of `LibraryContext`.
- Register repositories (`ILibraryRepository`, `IBookRepository`) and services (`ILibrariesService`, `IBooksService`) in `Startup.cs` with Transient lifetime.
- Preserve existing Web API contracts, controller endpoints, DTO formats, and integration tests.

**Non-Goals:**
- Split into multiple `.csproj` class library projects (keeping single-project folder structure for this phase).
- Modify database schemas, migrations, or HTTP routes.

## Decisions

**D1. Repository Contracts in Application Layer**  
Place `ILibraryRepository` and `IBookRepository` under `Application/Interfaces/Repositories/` in namespace `LibraryService.WebAPI.Application.Interfaces.Repositories`. This satisfies the Dependency Inversion Principle since Application defines the interfaces it needs.

**D2. Repository Implementations in Infrastructure Layer**  
Place `LibraryRepository` and `BookRepository` under `Infrastructure/Repositories/` in namespace `LibraryService.WebAPI.Infrastructure.Repositories`. They consume `LibraryContext` to perform EF Core database queries/commands.

**D3. Decouple Services from DbContext**  
`LibrariesService` and `BooksService` inject `ILibraryRepository` and `IBookRepository` respectively. No EF Core `DbContext` types appear in Application services.

## Risks / Trade-offs

- Additional abstraction layer (Repositories) → Mitigation: standard .NET pattern, simplifies unit testing and persistence switching.
