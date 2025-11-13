using BookShelf.API.DTO;
using BookShelf.API.Entities;
using BookShelf.API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _authorService.AddAuthor(authorCreate);
            return Ok();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllAuthor()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

    }
}
