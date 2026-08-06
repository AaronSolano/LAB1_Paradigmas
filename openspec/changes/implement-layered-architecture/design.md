## Context

Single Project References current layout — everything in one assembly `HackerRank1` with sibling folders:

```
HackerRank1/
  Services/      BooksService(+ IBooksService), LibrariesService(+ ILibrariesService)
                                                       → LibraryService.WebAPI.Services
  DTO/           BookForm, LibraryForm                  → LibraryService.WebAPI.DTO
  Data/          LibraryContext, Book, Library          → LibraryService.WebAPI.Data
  Migrations/    EF migrations (refer to entities + context)
  Startup.cs     (registers LibrariesService/BooksService + LibraryContext)  Program.cs
```

Today controllers inject the EF-connected services directly; services touch the `DbContext`; entities and the `DbContext` live in the same `Data/` folder. There is no enforced boundary between HTTP, application logic, domain, and persistence. See proposal.md - Why.

## Goals / Non-Goals

**Goals:**
- Introduce four clear layer folders in the single `HackerRank1` project with a single dependency direction (Presentation → Application → Domain; Infrastructure referenced by Application/persistence).
- Decouple controllers from persistence by keeping services above the `DbContext`.
- Move entities into a `Domain` layer and the `DbContext` into `Infrastructure`, so domain does not depend on EF.
- Preserve every externally observable behavior: routes, status codes, bodies, connection string, InMemory/Npgsql setup, service lifetimes (Transient).

**Non-Goals:**
- Implement the `NotImplementedException` stubs (explicitly out of scope).
- Split into separate `.csproj` assemblies (user chose single-project folder layers).
- Validate/convert entities into DTOs in the controllers (currently `BooksController`/`LibrariesController` bind to entities; changing that is behavior-relevant and out of scope).
- Refactor `BooksService`/`LibrariesService` API signatures or persistence behavior.

## Decisions

**D1. Layer folder + namespace mapping.** New layout and namespaces:

```
Presentation/Controllers/BooksController.cs       → LibraryService.WebAPI.Presentation.Controllers
Presentation/Controllers/LibrariesController.cs   → LibraryService.WebAPI.Presentation.Controllers
Application/Services/BookService.cs               → LibraryService.WebAPI.Application.Services (IBooksService, BooksService)
Application/Services/LibraryService.cs            → LibraryService.WebAPI.Application.Services (ILibrariesService, LibrariesService)
Application/DTO/BookForm.cs                       → LibraryService.WebAPI.Application.DTO (BookForm)
Application/DTO/LibraryForm.cs                    → LibraryService.WebAPI.Application.DTO (LibraryForm)
Domain/Entities/Book.cs                        → LibraryService.WebAPI.Domain.Entities (Book)
Domain/Entities/Library.cs                     → LibraryService.WebAPI.Domain.Entities (Library)
Infrastructure/Data/LibraryContext.cs          → LibraryService.WebAPI.Infrastructure.Data (LibraryContext)
```

Rationale: standard .NET layering; Application is the home for the application services and their request/response DTOs. Alternative considered (keep everything in-place, just add folders of top-level nesting): rejected because it would not actually bound the layers, and the point of this restructuring is to draw those boundaries.

**D2. Split `Data/` into Domain + Infrastructure.** `Book`/`Library` are pure domain entities, so they move to `Domain`. `LibraryContext` is storage infrastructure and stays in `Infrastructure`. Rationale: keeps EF out of the domain layer so domain stays free of persistence concerns.

**D3. Keep interface + implementation co-located in `Application`.** In a single project, `IBooksService`/`ILibrariesService` remain in the same file/folder as `BooksService`/`LibrariesService`. Alternative (extracted `Application.Abstractions` namespace) rejected: adds indirection with no compilation-time benefit in one assembly.

**D4. Migrations follow the relocated types.** Update the `Migrations/*.cs` `Designer`/`Snapshot` references so the EF model namespaces match the new `Domain`/`Infrastructure` namespaces. Keep the migration SQL/behavior identical (no schema change).

**D5. Update all referencing code in the same change.** `Startup.cs`, `Program/`, and the `LibraryService.Integration.Test` project (which `using`s `LibraryService.WebAPI.Data`, `.DTO`, `.WebAPI`) must be updated to the new namespaces in the same change or the build breaks.

## Risks / Trade-offs

- **Build break from namespace cascade** → All referent files (Startup, Migrations, Integration Test, `IntegrationTest/` copy) updated in the same change; run `dotnet build` as verification.
- **Behavior regression despite "no behavior change"** → Re-run the integration tests; they define 201/404/200/204 contracts and must stay green.
- **Orphan duplicate test project** (`IntegrationTest/` copy of the tests) → Not touched here (out of scope); noted so the known duplicate doesn't silently cause confusion.
- **Single-project layer = soft boundary** → Layers are enforced by convention, not at-build containment, since there is only one assembly. Acceptable trade of the user's chosen approach; mitigated by disciplined namespaces.