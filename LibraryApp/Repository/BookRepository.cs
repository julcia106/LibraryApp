using System.Collections.Generic;
using System.Linq;
using LibraryApp.Data;
using LibraryApp.Models;
using LibraryApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            var bookToUpdate = _context.Books.Find(book.Id);

            bookToUpdate.Name = book.Name;
            bookToUpdate.AuthorName = book.AuthorName;
            bookToUpdate.GenreId = book.GenreId;
            bookToUpdate.ReleaseDate = book.ReleaseDate;
            bookToUpdate.DateAdded = book.DateAdded;
            bookToUpdate.NumberInStock = book.NumberInStock;
        }

        public void Delete(int id)
        {
            var book = this.Get(id);
            _context.Books.Remove(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                .Include(x => x.Genre)
                .ToList();

        }

        public Book Get(int id)
        {
            return _context.Books.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}