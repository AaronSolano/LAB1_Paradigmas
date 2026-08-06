using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.WebAPI.Domain.Entities;

namespace LibraryService.WebAPI.Application.Interfaces.Repositories
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAsync(int[]? ids);
        Task<Library?> GetByIdAsync(int id);
        Task<Library> AddAsync(Library library);
        Task<IEnumerable<Library>> AddRangeAsync(IEnumerable<Library> libraries);
        Task<Library> UpdateAsync(Library library);
        Task<bool> DeleteAsync(Library library);
    }
}
