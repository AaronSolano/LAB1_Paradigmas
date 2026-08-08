## Context

The solution currently follows a traditional layered folder layout (Controllers, Services, Data, DTO). The goal is to transition HackerRank1 into a pure Vertical Slice Architecture based on the Autonomous Feature Island pattern.

## Goals / Non-Goals

**Goals:**
- Eliminate all horizontal layer directories (Controllers, Services, Data, DTO).
- Create a top-level Features/ directory containing self-contained feature slices (CreateLibrary, GetLibraries, GetLibraryById, UpdateLibrary, DeleteLibrary, CreateBook, GetBooks).
- Encapsulate the Endpoint, DTOs, Handler logic, and DB operations in each feature slice.
- Maintain LibraryContext configuration, EF Core InMemory setup, Supabase PostgreSQL readiness, and Swagger registration in Startup.cs / Program.cs.
- Ensure all integration tests in IntegrationTest compile and pass.

**Non-Goals:**
- Changing external API endpoint contracts or routing schemes.
- Introducing heavy third-party Mediator libraries (e.g. MediatR) unless necessary; standard ASP.NET Core endpoints and concise in-slice handlers keep slices lightweight and autonomous.

## Target Physical Architecture

`
HackerRank1/
├── Data/                             <-- Retained only for global DbContext & shared domain entities
│   └── LibraryContext.cs
├── Features/                         <-- Autonomous Feature Islands
│   ├── Libraries/
│   │   ├── CreateLibrary/
│   │   │   ├── CreateLibraryEndpoint.cs
│   │   │   └── CreateLibraryRequest.cs
│   │   ├── GetLibraries/
│   │   │   └── GetLibrariesEndpoint.cs
│   │   ├── GetLibraryById/
│   │   │   └── GetLibraryByIdEndpoint.cs
│   │   ├── UpdateLibrary/
│   │   │   ├── UpdateLibraryEndpoint.cs
│   │   │   └── UpdateLibraryRequest.cs
│   │   └── DeleteLibrary/
│   │       └── DeleteLibraryEndpoint.cs
│   └── Books/
│       ├── CreateBook/
│       │   ├── CreateBookEndpoint.cs
│       │   └── CreateBookRequest.cs
│       └── GetBooks/
│           └── GetBooksEndpoint.cs
├── Program.cs
└── Startup.cs
`

## Decisions

### Decision 1: Autonomous Feature Controllers
- **Choice**: Place ASP.NET Core [ApiController] classes directly inside each feature slice directory (e.g. Features/Libraries/CreateLibrary/CreateLibraryEndpoint.cs).
- **Rationale**: Keeps endpoints completely co-located with request DTOs and database logic for that slice, eliminating cross-folder hunting.

### Decision 2: Direct DbContext Usage in Slices vs Separate Services
- **Choice**: Slices interact directly with LibraryContext (or lightweight internal slice handlers) rather than through indirect service interfaces (ILibrariesService, IBooksService).
- **Rationale**: Eliminates unnecessary abstraction layers in simple CRUD/Feature island operations while improving slice autonomy.

### Decision 3: Shared Domain Entity Models & DbContext Location
- **Choice**: Maintain LibraryContext, Library, and Book models in Data/ (or Shared/Data/).
- **Rationale**: EF Core context requires access to DbSet<Library> and DbSet<Book>. Keeping shared EF Core schema definition clean prevents entity duplication while allowing feature islands to remain autonomous.

## Risks / Trade-offs

- **[Risk]**: Moving files breaks existing namespaces.
  - **Mitigation**: Perform systematic namespace refactoring across HackerRank1 and update using statements in IntegrationTest/IntegrationTest.cs.
- **[Risk]**: Duplicate code in DTOs across features.
  - **Trade-off**: Preferred trade-off in Vertical Slice Architecture to guarantee independent evolution of feature inputs/outputs without tight coupling.
