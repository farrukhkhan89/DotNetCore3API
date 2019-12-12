using CourseLibrary.API.Entities;
using CourseLibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
    // use this for MongodDb
    public interface IBooksRepository
    {
        public List<Book> Get();
        public Book CreateBook(Book book);

        Task<List<Book>> GetBooksAsync();


        public Task<Book> GetById(string id);
    }
}
