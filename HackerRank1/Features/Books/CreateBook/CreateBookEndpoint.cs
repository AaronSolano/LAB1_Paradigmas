using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Books.CreateBook
{
    [ApiController]
    [Route("api/libraries/{libraryId}/books")]
    public class CreateBookEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public CreateBookEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(int libraryId, [FromBody] CreateBookRequest request)
        {
            var library = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == libraryId);
            if (library == null)
                return NotFound();

            var book = new Book
            {
                Name = request.Name ?? "",
                Category = request.Category ?? "",
                LibraryId = libraryId
            };

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return StatusCode(201, book);
        }
    }
}
