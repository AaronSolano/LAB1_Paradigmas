using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Application.Interfaces.Repositories;
using LibraryService.WebAPI.Domain.Entities;
using LibraryService.WebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetByLibraryIdAsync(int libraryId, int[]? ids)
        {
            var query = _context.Books.Where(b => b.LibraryId == libraryId);

            if (ids != null && ids.Any())
            {
                query = query.Where(b => ids.Contains(b.Id));
            }

            return await query.ToListAsync();
        }

        public async Task<Book> AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            var existing = await _context.Books.SingleAsync(b => b.Id == book.Id);
            existing.Name = book.Name;
            existing.Category = book.Category;

            _context.Books.Update(existing);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteAsync(Book book)
        {
            var existing = await _context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
            if (existing == null)
                return false;

            _context.Books.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
