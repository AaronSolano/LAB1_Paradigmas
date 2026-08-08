using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Libraries.GetLibraries
{
    [ApiController]
    [Route("api/libraries")]
    [Tags("Libraries")]
    public class GetLibrariesEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public GetLibrariesEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLibraries()
        {
            var libraries = await _context.Libraries.ToListAsync();
            return Ok(libraries);
        }
    }
}
