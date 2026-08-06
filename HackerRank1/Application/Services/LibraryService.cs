<<<<<<< HEAD
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.WebAPI.Application.Interfaces.Repositories;
using LibraryService.WebAPI.Domain.Entities;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Domain.Entities;
using LibraryService.WebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
>>>>>>> origin/main

namespace LibraryService.WebAPI.Application.Services
{
    public class LibrariesService : ILibrariesService
    {
<<<<<<< HEAD
        private readonly ILibraryRepository _libraryRepository;

        public LibrariesService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
=======
        private readonly LibraryContext _libraryContext;

        public LibrariesService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
>>>>>>> origin/main
        }

        public async Task<IEnumerable<Library>> Get(int[] ids)
        {
<<<<<<< HEAD
            return await _libraryRepository.GetAsync(ids);
=======
            var projects = _libraryContext.Libraries.AsQueryable();

            if (ids != null && ids.Any())
                projects = projects.Where(x => ids.Contains(x.Id));

            return await projects.ToListAsync();
>>>>>>> origin/main
        }

        public async Task<Library> Add(Library library)
        {
<<<<<<< HEAD
            return await _libraryRepository.AddAsync(library);
=======
            await _libraryContext.Libraries.AddAsync(library);

            await _libraryContext.SaveChangesAsync();
            return library;
>>>>>>> origin/main
        }

        public async Task<IEnumerable<Library>> AddRange(IEnumerable<Library> projects)
        {
<<<<<<< HEAD
            return await _libraryRepository.AddRangeAsync(projects);
=======
            await _libraryContext.Libraries.AddRangeAsync(projects);
            await _libraryContext.SaveChangesAsync();
            return projects;
>>>>>>> origin/main
        }

        public async Task<Library> Update(Library library)
        {
<<<<<<< HEAD
            return await _libraryRepository.UpdateAsync(library);
=======
            var projectForChanges = await _libraryContext.Libraries.SingleAsync(x => x.Id == library.Id);
            projectForChanges.Name = library.Name;
            projectForChanges.Location = library.Location;

            _libraryContext.Libraries.Update(projectForChanges);
            await _libraryContext.SaveChangesAsync();
            return library;
>>>>>>> origin/main
        }

        public async Task<bool> Delete(Library library)
        {
<<<<<<< HEAD
            return await _libraryRepository.DeleteAsync(library);
=======
            // Complete the implementation
            throw new NotImplementedException();
>>>>>>> origin/main
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
