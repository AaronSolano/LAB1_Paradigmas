## Purpose

Provides a structured RESTful API service to manage libraries and their associated books using a clear layered architecture separation.

## ADDED Requirements

### Requirement: Layered Architecture Separation
The Web API system SHALL organize code into distinct Presentation, Application, Domain, and Infrastructure layers.

#### Scenario: Layered component isolation
- **WHEN** requests are handled by the system
- **THEN** Presentation controllers delegate to Application services, which operate on Domain entities and utilize Infrastructure persistence.

### Requirement: Library Management API
The system SHALL support retrieving, adding, updating, and deleting libraries via the `/api/libraries` endpoint.

#### Scenario: Retrieve library list
- **WHEN** a GET request is sent to `/api/libraries`
- **THEN** the system returns HTTP 200 OK with a list of libraries.

#### Scenario: Retrieve library by ID
- **WHEN** a GET request is sent to `/api/libraries/{libraryId}` for an existing library
- **THEN** the system returns HTTP 200 OK with the library details.

### Requirement: Book Management API
The system SHALL support adding and retrieving books for a specific library via `/api/libraries/{libraryId}/books`.

#### Scenario: Add book to existing library
- **WHEN** a valid POST request with book details is sent to `/api/libraries/{libraryId}/books` for an existing library
- **THEN** the system creates the book and returns HTTP 201 Created.

#### Scenario: Retrieve books for existing library
- **WHEN** a GET request is sent to `/api/libraries/{libraryId}/books` for an existing library
- **THEN** the system returns HTTP 200 OK with the collection of books associated with that library.
