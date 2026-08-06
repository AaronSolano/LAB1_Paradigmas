## Purpose

Provides a structured RESTful API service for library and book management designed with Clean Architecture principles, strict Dependency Inversion, repository abstractions, and clear layer isolation.

## ADDED Requirements

### Requirement: Clean Architecture Dependency Inversion
The Web API solution SHALL enforce Dependency Inversion by isolating pure Domain entities, defining repository interfaces in Application, and encapsulating database concerns within Infrastructure repository implementations.

#### Scenario: Application layer decouples from persistence infrastructure
- **WHEN** application services execute business operations for libraries or books
- **THEN** they interact exclusively with repository interface contracts defined in the Application layer without directly coupling to EF Core DbContext types.

### Requirement: Repository Abstraction Layer
The system SHALL provide repository abstractions (`ILibraryRepository`, `IBookRepository`) that isolate persistence logic from application services.

#### Scenario: Persistence operations via repository implementations
- **WHEN** data operations are performed for libraries or books
- **THEN** Infrastructure repositories execute queries and commands against the database context and return domain entities to the application services.

### Requirement: Web API Contract Preservation
The system SHALL maintain complete compatibility for library and book REST endpoints across `/api/libraries` and `/api/libraries/{libraryId}/books`.

#### Scenario: Retrieve library list
- **WHEN** a GET request is sent to `/api/libraries`
- **THEN** Presentation controllers delegate to Application services and return HTTP 200 OK with the library collection.

#### Scenario: Retrieve library by ID
- **WHEN** a GET request is sent to `/api/libraries/{libraryId}` for an existing library
- **THEN** the system returns HTTP 200 OK with the library details.

#### Scenario: Add book to existing library
- **WHEN** a valid POST request with book details is sent to `/api/libraries/{libraryId}/books` for an existing library
- **THEN** the system creates the book and returns HTTP 201 Created.
