## Why

The `HackerRank1` project is a single flat assembly with `Controllers/`, `Services/`, `Data/`, and `DTO/` folders all sitting side by side, with no enforced dependency direction. Controllers reach straight into EF Core entities and the `LibraryContext`, coupling HTTP concerns to persistence. As the service grows this makes the code hard to test, reason about, and evolve. We want a classic .NET layered structure (single project, clear layer folders) so each layer depends only on the layer below it and persistence is hidden behind interfaces.

## What Changes

- Reorganize the `HackerRank1` project into four layer folders:
  - `Presentation/` — the HTTP/ASP.NET surface: the two controllers (moved from `Controllers/`).
  - `Application/` — service interfaces and implementations (`IBooksService`, `BooksService`, `ILibrariesService`, `LibrariesService`) and the request/response forms (moved from `Services/` and `DTO/`).
  - `Domain/` — the pure entities `Book` and `Library` (moved from `Data/`).
  - `Infrastructure/` — the `LibraryContext` DbContext (moved from `Data/`).
- Move service interface definitions into the same `Application` layer as their implementations (single project; no new assemblies).
- Update namespaces to reflect the new folders.
- No changes to HTTP endpoints, routes, status codes, JSON contract, or Database registration.
- The `NotImplementedException` stubs (DELETE library, POST/GET books, service methods) are intentionally left untouched — out of scope for this change.

## Capabilities

### New Capabilities

- `library-service`: Manages libraries and books via a layered Web API with structured presentation, application, domain, and infrastructure layers.

### Modified Capabilities

None.

## Impact

- Affected code: `HackerRank1/Controllers/*`, `HackerRank1/Services/*`, `HackerRank1/DTO/*`, `HackerRank1/Data/*` — files move to new layer folders and get new namespaces.
- Referenced by: `HackerRank1/Startup.cs`, `HackerRank1/Program.cs`, `HackerRank1/README.md` (DI/registration already done), and the integration test project `LibraryService.Integration.Test` (which references `LibraryService.WebAPI.Data`, `DTO`, and `WebAPI` namespaces — these namespace moves may require test-project updates).
- Dependencies: unchanged. EF Core (InMemory, Npgsql), Newtonsoft.Json, Swashbuckle, MSTest remain as-is.
- System impact: none at runtime; the compiled assembly name, routes, and service lifetimes (Transient) are preserved.