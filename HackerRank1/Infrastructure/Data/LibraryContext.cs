using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Domain.Entities;

namespace LibraryService.WebAPI.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
