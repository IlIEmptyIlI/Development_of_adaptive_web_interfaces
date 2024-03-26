using Microsoft.AspNetCore.Mvc;
using Laba8.Models;
using Laba8.Services;

namespace Laba8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _userService.AddUser(user);
            return Ok("User registered successfully.");
        }


        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var existingUser = _userService.GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            if (existingUser.Password != user.Password)
            {
                return Unauthorized("Invalid password.");
            }

            return Ok("Login successful.");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            _userService.GetAllUsers();
            return Ok(_userService.GetAllUsers());
        }

    }
}
