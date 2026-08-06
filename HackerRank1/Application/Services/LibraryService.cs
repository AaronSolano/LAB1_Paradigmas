using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.WebAPI.Application.Interfaces.Repositories;
using LibraryService.WebAPI.Domain.Entities;

namespace LibraryService.WebAPI.Application.Services
{
    public class LibrariesService : ILibrariesService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibrariesService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<IEnumerable<Library>> Get(int[] ids)
        {
            return await _libraryRepository.GetAsync(ids);
        }

        public async Task<Library> Add(Library library)
        {
            return await _libraryRepository.AddAsync(library);
        }

        public async Task<IEnumerable<Library>> AddRange(IEnumerable<Library> projects)
        {
            return await _libraryRepository.AddRangeAsync(projects);
        }

        public async Task<Library> Update(Library library)
        {
            return await _libraryRepository.UpdateAsync(library);
        }

        public async Task<bool> Delete(Library library)
        {
            return await _libraryRepository.DeleteAsync(library);
        }
    }

    public interface ILibrariesService
    {
        Task<IEnumerable<Library>> Get(int[] ids);

        Task<Library> Add(Library library);

        Task<Library> Update(Library library);

        Task<bool> Delete(Library library);
    }
}
