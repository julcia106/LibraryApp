using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Models;

namespace LibraryApp.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Book Book { get; set; }
        public string Title
        {
            get
            {
                if(Book != null && Book.Id != 0)
                {
                    return "Edit book";
                }

                return "New book";
            }
        }
    }
}
