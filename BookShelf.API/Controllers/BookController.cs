using BookShelf.API.Entities;
using BookShelf.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks().ToList();
            return Ok(books);
        }

        [HttpGet("GetBook/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = _bookService.GetBookById(id);
            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
            existingBook.Year = book.Year;
            _bookService.UpdateBook(existingBook);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookService.GetBookById(id);
            _bookService.DeleteBook(existingBook);
            return Ok();
        }

    }
}
