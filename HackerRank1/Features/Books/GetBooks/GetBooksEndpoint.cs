using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Books.GetBooks
{
    [ApiController]
    [Route("api/libraries/{libraryId}/books")]
    public class GetBooksEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public GetBooksEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(int libraryId)
        {
            var libraryExists = await _context.Libraries.AnyAsync(l => l.Id == libraryId);
            if (!libraryExists)
                return NotFound();

            var books = await _context.Books.Where(b => b.LibraryId == libraryId).ToListAsync();
            return Ok(books);
        }
    }
}
