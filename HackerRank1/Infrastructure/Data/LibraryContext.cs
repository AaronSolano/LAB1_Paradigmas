<<<<<<< HEAD
using LibraryService.WebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Domain.Entities;
>>>>>>> origin/main

namespace LibraryService.WebAPI.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

<<<<<<< HEAD
        public DbSet<Library> Libraries { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
=======
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
>>>>>>> origin/main
    }
}
