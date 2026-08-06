using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data.Entities;

namespace LibraryService.WebAPI.Business.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetByLibraryIdAsync(int libraryId, int[]? ids);
        Task<Book> AddAsync(Book book);
        Task<Book> UpdateAsync(Book book);
        Task<bool> DeleteAsync(Book book);
    }
}
