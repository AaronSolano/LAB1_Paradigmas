using LibraryService.WebAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Data.DbContext
{
    public class LibraryContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Library> Libraries { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
    }
}
