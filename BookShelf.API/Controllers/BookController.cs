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

        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks().ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("books/{id}")]
        public IActionResult GetBook(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("books")]
        public IActionResult AddBook([FromBody] BookCreateDto dto)
        {
            try
            {
                _bookService.AddBook(dto);
                return Ok("Book added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("books/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] BookUpdateDto dto)
        {
            try
            {
                var existingBook = _bookService.GetBookById(id);

                existingBook.Title = dto.Title;
                existingBook.AuthorId = dto.AuthorId;
                existingBook.Year = dto.Year;

                _bookService.UpdateBook(existingBook);
                return Ok("Book updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("books/{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var existingBook = _bookService.GetBookById(id);
                _bookService.DeleteBook(existingBook);
                return Ok("Book deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
