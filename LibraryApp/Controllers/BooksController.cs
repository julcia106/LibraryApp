using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LibraryApp.Models;
using LibraryApp.Data;
using LibraryApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using LibraryApp.Repository;
using AutoMapper;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using System.Collections.Generic;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBookRepository _bookRepository;

        public BooksController(ApplicationDbContext context, IBookRepository bookRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
        }

        [Authorize(Roles = "User,StoreManager,Owner")]
        public IActionResult Index()
        {
            var books = _bookRepository.GetAll();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.Get(id);

            return View(book);
        }

        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult Edit(int id)
        {
            var book = _bookRepository.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genre.ToList()
            };

            return View("BookForm", viewModel);
        }

        [Authorize(Roles = "StoreManager,Owner")]
        public IActionResult New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = _context.Genre.ToList()
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                return New();
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                _bookRepository.Add(book);
            }
            else
            {
                _bookRepository.Update(book);
            }

            try
            {
                _bookRepository.Save();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Books");
        }
    }
}
