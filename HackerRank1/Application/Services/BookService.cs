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
    public class BooksService : IBooksService
    {
<<<<<<< HEAD
        private readonly IBookRepository _bookRepository;

        public BooksService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
=======
        private readonly LibraryContext _libraryContext;

        public BooksService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
>>>>>>> origin/main
        }

        public async Task<IEnumerable<Book>> Get(int libraryId, int[] ids)
        {
<<<<<<< HEAD
            return await _bookRepository.GetByLibraryIdAsync(libraryId, ids);
=======
            // Complete the implementation
            throw new NotImplementedException();
>>>>>>> origin/main
        }

        public async Task<Book> Add(Book book)
        {
<<<<<<< HEAD
            return await _bookRepository.AddAsync(book);
=======
            // Complete the implementation
            throw new NotImplementedException();
>>>>>>> origin/main
        }

        public async Task<Book> Update(Book book)
        {
<<<<<<< HEAD
            return await _bookRepository.UpdateAsync(book);
=======
            // Complete the implementation
            throw new NotImplementedException();
>>>>>>> origin/main
        }

        public async Task<bool> Delete(Book book)
        {
<<<<<<< HEAD
            return await _bookRepository.DeleteAsync(book);
=======
            // Complete the implementation
            throw new NotImplementedException();
>>>>>>> origin/main
        }
    }

    public interface IBooksService
    {
        Task<IEnumerable<Book>> Get(int libraryId, int[] ids);

        Task<Book> Add(Book book);

        Task<Book> Update(Book book);

        Task<bool> Delete(Book book);
    }
}
