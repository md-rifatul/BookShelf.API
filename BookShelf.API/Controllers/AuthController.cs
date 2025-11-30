using BookShelf.API.Data;
using BookShelf.API.DTO;
using BookShelf.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(u=>u.UserName==userLoginDto.Username);
            if (user == null)
            {
                return NotFound();
            }

            var result = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashPassword, userLoginDto.Password);

            if (result== PasswordVerificationResult.Failed)
            {
                return null;
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
