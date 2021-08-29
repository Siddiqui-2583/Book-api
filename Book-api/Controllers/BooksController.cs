using Book_api.BookData;
using Book_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_api.Controllers
{

    [ApiController]
    public class BooksController : ControllerBase
    {
        
        private IBookData _bookData;
        public BooksController(IBookData bookData)
        {
            _bookData = bookData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetBooks()
        {
            return Ok(_bookData.GetBooks());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _bookData.GetBook(id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound($"Book with id {id} not found!");
            
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddBook(Book book)
        {
            _bookData.AddBook(book);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + book.id, book);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteBook(Guid id)
        {
            var book = _bookData.GetBook(id);
            if (book != null)
            {
                _bookData.DeleteBook(book);
                return Ok($"Book with id {id} has been deleted!");
            }
            return NotFound($"Book with id {id} not found!");

        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditBook(Guid id, Book book)
        {
            var existingBook = _bookData.GetBook(id);
            if (existingBook != null)
            {
                book.id = existingBook.id;
                _bookData.EditBook(book);
                return Ok($"Book with id {id} has been Edited.");
            }
            return NotFound($"Book with id {id} not found!");

        }
    }
}
