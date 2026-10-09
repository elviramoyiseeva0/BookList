using Microsoft.AspNetCore.Mvc;
using System.Text;
using BookList.Models;
using BookList.ViewModel;
using BookList.Services;

namespace BookList.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetBooks());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddBook(new Book
                {
                    Id = _bookService.GetBooks().Count() + 1,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    Year = book.Year
                });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var st = new StringBuilder("<ul>");
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        st.Append($"<li>{error.ErrorMessage}</li>");
                    }
                }
                st.Append("</ul>");
                book.Errors = st.ToString();

                return View(book);
            }
        }
    }
}
