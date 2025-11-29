using BookShelf.API.Data;
using BookShelf.API.DTO;
using BookShelf.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthController(IConfiguration configuration, ApplicationDbContext applicationDbContext)
        {
            _configuration = configuration;
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost("register")]

        public IActionResult Register(UserCreateDto userCreateDto)
        {
            if (_applicationDbContext.Users.Any(x => x.UserName == userCreateDto.Username))
            {
                return BadRequest();
            }
            var user = new User();
            var hashPassword = new PasswordHasher<User>().HashPassword(user, userCreateDto.Password);

            user.UserName = userCreateDto.Username;
            user.HashPassword = hashPassword;
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return Ok();
        }
    }
}
