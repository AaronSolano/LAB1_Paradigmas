## 1. Application Layer Repository Contracts

- [x] 1.1 Create `Application/Interfaces/Repositories/ILibraryRepository.cs` defining `GetAsync`, `GetByIdAsync`, `AddAsync`, `AddRangeAsync`, `UpdateAsync`, and `DeleteAsync`.
- [x] 1.2 Create `Application/Interfaces/Repositories/IBookRepository.cs` defining `GetByLibraryIdAsync`, `AddAsync`, `UpdateAsync`, and `DeleteAsync`.

## 2. Infrastructure Layer Repository Implementations

- [x] 2.1 Create `Infrastructure/Repositories/LibraryRepository.cs` implementing `ILibraryRepository` with `LibraryContext`.
- [x] 2.2 Create `Infrastructure/Repositories/BookRepository.cs` implementing `IBookRepository` with `LibraryContext`.

## 3. Application Layer Services Refactoring

- [x] 3.1 Update `LibrariesService` in `Application/Services/LibraryService.cs` to inject `ILibraryRepository` instead of `LibraryContext`.
- [x] 3.2 Update `BooksService` in `Application/Services/BookService.cs` to inject `IBookRepository` instead of `LibraryContext`.

## 4. Presentation & Dependency Injection Wiring

- [x] 4.1 Update `Startup.cs` to register `ILibraryRepository` -> `LibraryRepository` and `IBookRepository` -> `BookRepository` in DI container.
- [x] 4.2 Verify `LibrariesController` and `BooksController` in Presentation layer consume `ILibrariesService` and `IBooksService` through Dependency Inversion.

## 5. Verification & Testing

- [x] 5.1 Build the solution (`dotnet build`) to confirm zero compilation errors.
- [x] 5.2 Verify all integration test usings and dependency registrations compile cleanly.
