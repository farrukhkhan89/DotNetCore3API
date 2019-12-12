using CourseLibrary.API.Entities;
using CourseLibrary.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Services
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IMongoCollection<Book> _books;

        public BooksRepository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BookStoreDb"));
            var database = client.GetDatabase("BookStoreDb");

            _books = database.GetCollection<Book>("Books");
        }

        public List<Book> Get() =>
            _books.Find(book => true).ToList();

        public Book CreateBook(Book book)
        {
            var bookNew = new Book
            {
                BookName = book.BookName,
                Author = book.Author,
                Category = book.Category,
                Price = book.Price
            };

            _books.InsertOne(bookNew);
            
            return null;
        }

        public async Task<List <Book>> GetBooksAsync()
        {
            var books = await _books.FindAsync(book => true);
            return await books.ToListAsync();

            //var users = await _users.FindAsync(user => true);
            //return await users.ToListAsync();

        }

        public async Task<Book> GetById(string id)
        {
            var repository = await _books.FindAsync(x => x.Id == id);
            return await repository.FirstOrDefaultAsync();
        }



    }
}
