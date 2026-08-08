using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Libraries.GetLibraryById
{
    [ApiController]
    [Route("api/libraries")]
    [Tags("Libraries")]
    public class GetLibraryByIdEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public GetLibraryByIdEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("{libraryId}")]
        public async Task<IActionResult> GetLibraryById(int libraryId)
        {
            var library = await _context.Libraries.FirstOrDefaultAsync(x => x.Id == libraryId);
            if (library == null)
                return NotFound();
            return Ok(library);
        }
    }
}
