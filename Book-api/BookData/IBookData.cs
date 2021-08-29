using Book_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_api.BookData
{
    public interface IBookData
    {
        List<Book> GetBooks();
        Book GetBook(Guid id);
        Book AddBook(Book book);
        void DeleteBook(Book book);
        Book EditBook(Book book);

    }
}
