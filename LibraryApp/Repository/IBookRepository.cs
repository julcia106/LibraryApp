using LibraryApp.Models;
using System.Collections.Generic;

namespace LibraryApp.Repository
{
    public interface IBookRepository // zad3
    {
        void Add(Book book);

        void Update(Book book);

        void Delete(int id);

        Book Get(int id);

        IEnumerable<Book> GetAll();

        void Save();
    }
}
