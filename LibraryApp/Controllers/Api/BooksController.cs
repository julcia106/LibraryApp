using AutoMapper;
using LibraryApp.Data;
using LibraryApp.Dtos;
using LibraryApp.Models;
using LibraryApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Controllers.Api
{
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(ApplicationDbContext context, IBookRepository bookRepository, IMapper mapper)
        {
            _context = context;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<BookDto> GetBooks(string query = null)
        {
            var booksQuery = _bookRepository.GetAll().Where(x => x.NumberAvailable > 0).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));
            }

            return booksQuery.ToList().Select(_mapper.Map<Book, BookDto>);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner")]
        public IActionResult RemoveBook(int id)
        {
            _bookRepository.Delete(id);
            _bookRepository.Save();
            return Ok();
        }
    }
}
