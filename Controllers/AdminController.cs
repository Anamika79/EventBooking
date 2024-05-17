using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        AdminController(IAdminService adminService) 
        {
            _adminService = adminService;
        }

        [HttpPost("addneweventcat")]

        public async Task<IActionResult> AddNewEventCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            else
            {
                await _adminService.AddCategoryAsync(category);
                return Ok("Added Successfully");
            }
        }

        
    }
}
