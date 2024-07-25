using App.FormApi.Data;
using App.FormApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.FormApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserContext _context;

        public RegisterController(UserContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest(new { error = "Email already exists." }); // JSON formatında hata mesajı döndür
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User registered successfully." }); // JSON formatında başarı mesajı döndür
        }
    }

}
