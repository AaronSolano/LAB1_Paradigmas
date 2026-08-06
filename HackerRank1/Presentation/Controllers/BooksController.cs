using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Application.DTO;
using LibraryService.WebAPI.Application.Services;
using LibraryService.WebAPI.Domain.Entities;

namespace LibraryService.WebAPI.Presentation.Controllers
{
    [ApiController]
    [Route("api/libraries/{libraryId}/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILibrariesService _librariesService;
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService, ILibrariesService librariesService)
        {
            _librariesService = librariesService;
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks(int libraryId)
        {
            var library = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (library == null)
                return NotFound();

            var books = await _booksService.Get(libraryId, null!);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(int libraryId, [FromBody] BookForm bookForm)
        {
            var library = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (library == null)
                return NotFound();

            var book = new Book
            {
                Name = bookForm.Name ?? string.Empty,
                Category = bookForm.Category ?? string.Empty,
                LibraryId = libraryId
            };

            await _booksService.Add(book);
            return StatusCode(StatusCodes.Status201Created, book);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBook(int libraryId, int bookId, [FromBody] BookForm bookForm)
        {
            var library = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (library == null)
                return NotFound();

            var existingBook = (await _booksService.Get(libraryId, new[] { bookId })).FirstOrDefault();
            if (existingBook == null)
                return NotFound();

            existingBook.Name = bookForm.Name ?? string.Empty;
            existingBook.Category = bookForm.Category ?? string.Empty;

            await _booksService.Update(existingBook);
            return NoContent();
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBook(int libraryId, int bookId)
        {
            var library = (await _librariesService.Get(new[] { libraryId })).FirstOrDefault();
            if (library == null)
                return NotFound();

            var existingBook = (await _booksService.Get(libraryId, new[] { bookId })).FirstOrDefault();
            if (existingBook == null)
                return NotFound();

            await _booksService.Delete(existingBook);
            return NoContent();
        }
    }
}
