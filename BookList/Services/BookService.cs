using BookList.Models;

namespace BookList.Services
{
    public class BookService
    {
        List<Book> books;

        public BookService()
        {
            books = new List<Book>
        {
            new Book { Id = 1, Title = "451 degrees Fahrenheit", Author = "Ray Bradbury", Genre = "Dystopian", Year = 1953 },
            new Book { Id = 2, Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Fantasy", Year = 1997 },
            new Book { Id = 3, Title = "The Hound of the Baskervilles", Author = "Arthur Conan Doyle", Genre = "Mystery", Year = 1902 }
        };
        }

        public IEnumerable<Book> GetBooks() => books;

        public void AddBook(Book book)
        {
            books.Add(book);
        }
    }
}
