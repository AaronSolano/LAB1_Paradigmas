using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Features.Libraries.CreateLibrary
{
    [ApiController]
    [Route("api/libraries")]
    [Tags("Libraries")]
    public class CreateLibraryEndpoint : ControllerBase
    {
        private readonly LibraryContext _context;

        public CreateLibraryEndpoint(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLibraryRequest request)
        {
            var library = new Library
            {
                Name = request.Name ?? "",
                Location = request.Location ?? ""
            };

            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();
            return Ok(library);
        }
    }
}
