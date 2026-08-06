using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Domain.Entities;
using LibraryService.WebAPI.Domain.Interfaces;
using LibraryService.WebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Library>> GetAsync(int[]? ids)
        {
            var query = _context.Libraries.AsQueryable();

            if (ids != null && ids.Any())
            {
                query = query.Where(x => ids.Contains(x.Id));
            }

            return await query.ToListAsync();
        }

        public async Task<Library?> GetByIdAsync(int id)
        {
            return await _context.Libraries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Library> AddAsync(Library library)
        {
            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();
            return library;
        }

        public async Task<IEnumerable<Library>> AddRangeAsync(IEnumerable<Library> libraries)
        {
            await _context.Libraries.AddRangeAsync(libraries);
            await _context.SaveChangesAsync();
            return libraries;
        }

        public async Task<Library> UpdateAsync(Library library)
        {
            var existing = await _context.Libraries.SingleAsync(x => x.Id == library.Id);
            existing.Name = library.Name;
            existing.Location = library.Location;

            _context.Libraries.Update(existing);
            await _context.SaveChangesAsync();
            return library;
        }

        public async Task<bool> DeleteAsync(Library library)
        {
            var existing = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == library.Id);
            if (existing == null)
                return false;

            _context.Libraries.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
