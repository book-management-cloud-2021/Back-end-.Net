using BookManagement.Entities;
using BookManagement.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookManagementContext _context;

        public BooksController(BookManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/books/search-books")]
        public ActionResult SearchBooks()
        {
            var books = _context.Books
                .Include(b => b.Category)
                .Include(b => b.Language)
                .Select(b => new BookViewModel
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    CategoryName = b.Category.CategoryName,
                    LanguageId = b.LanguageId,
                    LanguageName = b.Language.LanguageName,
                    Price = b.Price,
                    Amount = b.Amount,
                    PrintLength = b.PrintLength,
                    Publisher = b.Publisher,
                    ReleaseYear = b.ReleaseYear,
                }).ToList();

            if (books.Any())
                return Ok(books);

            return NotFound("No have any books!");
        }

        [HttpPost]
        [Route("api/languages/add-or-update-book")]
        public ActionResult AddOrUpdateBook(AddOrUpdateBookModel bookModel)
        {
            var existedBook = _context.Books
                .Where(b => b.Title.ToLower().Equals(bookModel.Title.ToLower()))
                .Where(b => b.CategoryId.Equals(bookModel.CategoryId))
                .Where(b => b.LanguageId.Equals(bookModel.LanguageId))
                .Where(b => b.Author.ToLower().Equals(bookModel.Author.ToLower()))
                .Where(b => b.ReleaseYear.Equals(bookModel.ReleaseYear))
                .Where(b => b.Publisher.ToLower().Equals(bookModel.Publisher.ToLower()));

            if (!existedBook.Any())
            {
                _context.Books.Add(new Book
                {
                    BookId = Guid.NewGuid(),
                    Title = bookModel.Title,
                    LanguageId = bookModel.LanguageId,
                    CategoryId = bookModel.CategoryId,
                    Author = bookModel.Author,
                    Price = bookModel.Price,
                    Amount = bookModel.Amount,
                    Description = bookModel.Description,
                    PrintLength = bookModel.PrintLength,
                    Publisher = bookModel.Publisher,
                    ReleaseYear = bookModel.ReleaseYear,
                    InsertedAt = DateTime.UtcNow
                });

                _context.SaveChanges();
            }
            else
            {
                var book = existedBook.Select(b => new Book
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    LanguageId = b.LanguageId,
                    CategoryId = b.CategoryId,
                    Author = b.Author,
                    Price = bookModel.Price,
                    Amount = bookModel.Amount,
                    Description = bookModel.Description,
                    PrintLength = b.PrintLength,
                    Publisher = b.Publisher,
                    ReleaseYear = b.ReleaseYear,
                    UpdatedAt = DateTime.UtcNow
                }).FirstOrDefault();

                _context.Update(book);

                _context.SaveChanges();
            }
            return Ok("Created a new book successfully !");
        }
    }
}
