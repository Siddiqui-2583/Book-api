using Book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_api.BookData
{
    public class MockBookData : IBookData
    {
        private List<Book> books = new List<Book>()
        {
            new Book()
            {
                id = Guid.NewGuid(),
                title = "Book one",
                writer = "Writer one",
                category = "category one",
                publication =  "Publication one"
            },
            new Book()
            {
                id = Guid.NewGuid(),
                title = "Book two",
                writer = "Writer two",
                category = "category two",
                publication =  "Publication two"
            }
        };
        
        public Book AddBook(Book book)
        {
            book.id = Guid.NewGuid();
            books.Add(book);
            return book;
        }

       

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }

        public Book EditBook(Book book)
        {
            var existingBook = GetBook(book.id);
            existingBook.title = book.title;
            existingBook.writer = book.writer;
            existingBook.category = book.category;
            existingBook.publication = book.publication;
            return book;
        }


        public Book GetBook(Guid id)
        {
            return books.SingleOrDefault(x => x.id == id);
        }

        public List<Book> GetBooks()
        {
            return books;
        }
    }
}
