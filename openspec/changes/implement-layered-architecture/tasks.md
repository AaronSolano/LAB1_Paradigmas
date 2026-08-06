## 1. Domain layer

- [x] 1.1 Create `HackerRank1/Domain/Entities/` and move `Book` to `Domain/Entities/Book.cs`, namespacing it `LibraryService.WebAPI.Domain.Entities`.
- [x] 1.2 Move `Library` to `Domain/Entities/Library.cs`, namespacing it `LibraryService.WebAPI.Domain.Entities`.
- [x] 1.3 Verify no behavior change: entity properties, `[Key]` attributes, and virtual navigation on `Book` preserved exactly.

## 2. Infrastructure layer

- [x] 2.1 Create `HackerRank1/Infrastructure/Data/` and move `LibraryContext` (the DbContext) to `Infrastructure/Data/LibraryContext.cs`, namespacing it `LibraryService.WebAPI.Infrastructure.Data`.
- [x] 2.2 Add `using LibraryService.WebAPI.Domain.Entities;` to `LibraryContext.cs` so the `Libraries`/`Books` DbSets resolve to the relocated entities.
- [x] 2.3 Build and confirm the project compiles with the new namespaces (expected: remaining breaks in Services/Controllers/DTO, addressed in later steps).

## 3. Application layer

- [x] 3.1 Move `BookService.cs` (`IBooksService` + `BooksService`) to `Application/Services/BookService.cs`, namespacing it `LibraryService.WebAPI.Application.Services`, and update its `using LibraryService.WebAPI.Data` to `LibraryService.WebAPI.Domain.Entities`.
- [x] 3.2 Move `LibraryService.cs` (`ILibrariesService` + `LibrariesService`) to `Application/Services/LibraryService.cs`, namespacing it `LibraryService.WebAPI.Application.Services`, and update its `using` to `LibraryService.WebAPI.Domain.Entities`.
- [x] 3.3 Move `BookForm` and `LibraryForm` to `Application/DTO/`, namespacing both `LibraryService.WebAPI.Application.DTO`.

## 4. Presentation layer

- [x] 4.1 Move `BooksController.cs` and `LibrariesController.cs` to `Presentation/Controllers/`, namespacing them `LibraryService.WebAPI.Presentation.Controllers`.
- [x] 4.2 Update the `using` statements in both controllers to reference `LibraryService.WebAPI.Application.Services` and `LibraryService.WebAPI.Domain.Entities`.

## 5. Wiring and migrations

- [x] 5.1 Delete the now-empty old folders (`Controllers/`, `Services/`, `DTO/`, `Data/`) once all files have moved.
- [x] 5.2 Update `Startup.cs` `using` directives for the new `Application.Services` and `Infrastructure.Data` namespaces; confirm the existing Transient registrations and DbContext registration still compile unchanged.
- [x] 5.3 Update EF `Migrations/*.cs` (initial + Designer + Snapshot) so model/context references use the relocated `Domain.Entities` and `Infrastructure.Data` namespaces; do not alter migration SQL or schema.

## 6. Test project and verification

- [x] 6.1 Update `LibraryService.Integration.Test/IntegrationTest.cs` `using`s so `Library`/`Book`/`LibraryContext` and `BookForm` resolve from the new namespaces.
- [x] 6.2 Update the orphan `IntegrationTest/IntegrationTest.cs` copy the same way (do not wire it into the solution; just keep it compiling/consistent if built).
- [x] 6.3 Restore + build the solution (`dotnet build`) — must succeed with no remaining references to `LibraryService.WebAPI.Services`, `.DTO`, or `.Data`.
- [x] 6.4 Run the integration tests (`dotnet test`) — all `TestAddBook`, `TestGetBooks`, `TestDeleteLibrary` cases stay green, confirming no behavior regression.