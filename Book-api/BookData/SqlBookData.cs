using Book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_api.BookData
{
    public class SqlBookData : IBookData
    {
        private BookContext _bookContext;
        public SqlBookData(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public Book AddBook(Book book)
        {
            book.id = Guid.NewGuid();
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
            return book;
        }

        public void DeleteBook(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }

        public Book EditBook(Book book)
        {
            var existingBook = _bookContext.Books.Find(book.id);
            if(existingBook != null)
            {
                existingBook.title = book.title;
                existingBook.writer = book.writer;
                existingBook.category = book.category;
                existingBook.publication = book.publication;
                _bookContext.Books.Update(existingBook);
                _bookContext.SaveChanges();
            }
            return book;
        }

        public Book GetBook(Guid id)
        {
            return _bookContext.Books.Find(id);
        }

        public List<Book> GetBooks()
        {
            return _bookContext.Books.ToList();
        }
    }
}
