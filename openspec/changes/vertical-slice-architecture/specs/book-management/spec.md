## Purpose

Provides autonomous vertical slice endpoints and business capabilities for managing book resources within libraries.

## ADDED Requirements

### Requirement: Autonomous Vertical Slices for Book Management
The system SHALL expose REST API endpoints for Book operations (Create Book, Read Books) scoped to a parent Library ID via self-contained feature slices under Features/.

#### Scenario: Adding a book to a library
- **WHEN** a client sends a POST request to /api/libraries/{libraryId}/books with a valid payload
- **THEN** the system SHALL invoke the CreateBook feature handler, attach the book to the target library, and return 201 Created if successful, or 404 Not Found if the library does not exist.

#### Scenario: Fetching all books of a library
- **WHEN** a client sends a GET request to /api/libraries/{libraryId}/books
- **THEN** the system SHALL invoke the GetBooks feature handler and return 200 OK with the collection of books if the library exists, or 404 Not Found if the library does not exist.
