<<<<<<< HEAD:HackerRank1/Controllers/LibrariesController.cs
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Application.Services;
using LibraryService.WebAPI.Domain.Entities;
=======
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Domain.Entities;
using LibraryService.WebAPI.Application.Services;
using LibraryService.WebAPI.Application.DTO;
>>>>>>> origin/main:HackerRank1/Presentation/Controllers/LibrariesController.cs

namespace LibraryService.WebAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibrariesService _librariesService;

        public LibrariesController(ILibrariesService librariesService)
        {
            _librariesService = librariesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libraries = await _librariesService.Get(null!);
            return Ok(libraries);
        }

        [HttpGet("{libraryId}")]
        public async Task<IActionResult> Get(int libraryId)
        {
            var library = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (library == null)
                return NotFound();
            return Ok(library);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Library l)
        {
            await _librariesService.Add(l);
            return Ok(l);
        }

        [HttpPut("{libraryId}")]
        public async Task<IActionResult> Update(int libraryId, [FromBody] Library library)
        {
            var existingLibrary = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (existingLibrary == null)
                return NotFound();

            library.Id = libraryId;
            await _librariesService.Update(library);
            return NoContent();
        }

        [HttpDelete("{libraryId}")]
        public async Task<IActionResult> Delete(int libraryId)
        {
            var existingLibrary = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (existingLibrary == null)
                return NotFound();

            await _librariesService.Delete(existingLibrary);
            return NoContent();
        }
    }
}
