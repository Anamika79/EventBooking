using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashService;

        public DashboardController(IDashboardService eventDashboardService)
        {
            _dashService = eventDashboardService;
        }

        [HttpGet("getcategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _dashService.GetCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("getevents")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsAsync()
        {
            try
            {
                var events = await _dashService.GetEventsAsync();
                return Ok(events);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
