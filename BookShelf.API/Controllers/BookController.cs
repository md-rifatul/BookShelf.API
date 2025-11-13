using BookShelf.API.DTO;
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
        public IActionResult AddBook([FromBody] BookCreateDto bookCreateDto)
        {
            _bookService.AddBook(bookCreateDto);
            return Ok();
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookUpdateDto bookUpdateDto)
        {
            var existingBook = _bookService.GetBookById(id);
            existingBook.Title = bookUpdateDto.Title;
            existingBook.AuthorId = bookUpdateDto.AuthorId;
            existingBook.Year = bookUpdateDto.Year;
            //_bookService.UpdateBook(existingBook);
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
