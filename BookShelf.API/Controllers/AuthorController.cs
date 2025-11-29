using BookShelf.API.DTO;
using BookShelf.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace BookShelf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Add")]
        public IActionResult AddAuthor([FromBody] AuthorCreate authorCreate)
        {
            try
            {
                _authorService.AddAuthor(authorCreate);
                return Ok("Author added successfully");
            }
            catch
            {
                return StatusCode(500, "Something went wrong while adding the author");
            }
        }

        [HttpGet("GetAll")]
        [EnableRateLimiting("Sliding")]
        public IActionResult GetAllAuthor()
        {
            try
            {
                var authors = _authorService.GetAllAuthors();
                return Ok(authors);
            }
            catch
            {
                return StatusCode(500, "Something went wrong while fetching authors");
            }
        }
    }
}
