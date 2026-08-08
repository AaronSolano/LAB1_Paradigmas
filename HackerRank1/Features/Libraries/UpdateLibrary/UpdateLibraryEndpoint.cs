using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Libraries.UpdateLibrary
{
    [ApiController]
    [Route("api/libraries")]
    [Tags("Libraries")]
    public class UpdateLibraryEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public UpdateLibraryEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpPut("{libraryId}")]
        public async Task<IActionResult> UpdateLibrary(int libraryId, [FromBody] UpdateLibraryRequest request)
        {
            var existingLibrary = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == libraryId);
            if (existingLibrary == null)
                return NotFound();

            existingLibrary.Name = request.Name ?? "";
            existingLibrary.Location = request.Location ?? "";

            _context.Libraries.Update(existingLibrary);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
