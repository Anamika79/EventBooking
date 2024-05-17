using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UserController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> UserLogin([FromBody] LoginUserDto obj)
        {
            try
            {
                var (result, token) = await _authService.UserLogin(obj);

                // Convert RegisterResult to IActionResult
                switch (result)
                {
                    case RegisterResult.LoginSuccess:
                        return Ok(new { Message = "Login Success!", Token = token });
                    case RegisterResult.UserNotFound:
                        return NotFound(new { Message = "User not found" });
                    case RegisterResult.WrongPassword:
                        return BadRequest(new { Message = "Wrong Password!" });
                    default:
                        return BadRequest(new { Message = "Unexpected error occurred" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing the request", Error = ex.Message });
            }
        }


        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] RegisterUserDto usr)
        {
            try
            {
                var result = await _authService.UserRegister(usr);

                // Convert RegisterResult to IActionResult
                switch (result)
                {
                    case RegisterResult.RegisterSuccess:
                        return Ok(new { Message = "User Registered!" });
                    case RegisterResult.EmailAlreadyExists:
                        return BadRequest(new { Message = "Email already exists!" });
                    case RegisterResult.WeakPassword:
                        return BadRequest(new { Message = "Password is weak!" });
                    default:
                        return BadRequest(new { Message = "Unexpected error occurred" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex });
            }
        }
    }

}
