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
        public IActionResult AddAuthor([FromBody] Author author)
        {
            _authorService.AddAuthor(author);
            return Ok();
        }

    }
}
