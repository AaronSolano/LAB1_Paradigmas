using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Libraries.DeleteLibrary
{
    [ApiController]
    [Route("api/libraries")]
    [Tags("Libraries")]
    public class DeleteLibraryEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public DeleteLibraryEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpDelete("{libraryId}")]
        public async Task<IActionResult> DeleteLibrary(int libraryId)
        {
            var library = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == libraryId);
            if (library == null)
                return NotFound();

            var books = await _context.Books.Where(b => b.LibraryId == libraryId).ToListAsync();
            if (books.Any())
            {
                _context.Books.RemoveRange(books);
            }

            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
