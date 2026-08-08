## Purpose

Provides autonomous vertical slice endpoints and business capabilities for managing library resources.

## ADDED Requirements

### Requirement: Autonomous Vertical Slices for Library Management
The system SHALL expose REST API endpoints for Library operations (Create, Read All, Read by ID, Update, Delete) implemented via self-contained vertical feature slices under Features/.

#### Scenario: Fetching all libraries
- **WHEN** a client sends a GET request to /api/libraries
- **THEN** the system SHALL invoke the GetLibraries feature handler and return a 200 OK HTTP response with a list of libraries.

#### Scenario: Fetching library by ID
- **WHEN** a client sends a GET request to /api/libraries/{libraryId}
- **THEN** the system SHALL invoke the GetLibraryById feature handler and return 200 OK if found, or 404 Not Found if missing.

#### Scenario: Creating a new library
- **WHEN** a client sends a POST request to /api/libraries with valid library details
- **THEN** the system SHALL invoke the CreateLibrary feature handler, persist the library, and return a 200 OK response with the created entity.

#### Scenario: Updating an existing library
- **WHEN** a client sends a PUT request to /api/libraries/{libraryId} with valid library updates
- **THEN** the system SHALL invoke the UpdateLibrary feature handler, update the entity, and return 204 No Content (or 404 Not Found if library is missing).

#### Scenario: Deleting a library
- **WHEN** a client sends a DELETE request to /api/libraries/{libraryId}
- **THEN** the system SHALL invoke the DeleteLibrary feature handler, remove the library and its associated books, and return 204 No Content (or 404 Not Found if missing).
