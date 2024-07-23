using App.FormApi.Data;
using App.FormApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.FormApi.Controllers
{
    [ApiController]
    [Route("/Register")]
    public class RegisterController : ControllerBase
    {
        private readonly UserContext _context;

        public RegisterController(UserContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email already exists.");
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully.");
        }
    }

}
