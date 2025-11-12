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

        [HttpGet("GetBook")]
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

    }
}
