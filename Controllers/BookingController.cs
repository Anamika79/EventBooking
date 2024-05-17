using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketBooking.Models;
using TicketBooking.Services;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService) 
        {
            _bookingService=bookingService;
        }

        [HttpPost("addnewbooking")]

        public async Task<IActionResult> AddNewBooking(EventBooking booking)
        {
            try
            {
                if (booking == null)
                {
                    return BadRequest("Null Value");
                }
                else
                {
                    await _bookingService.AddNewUserEventBooking(booking);
                    return Ok("Added Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("getevent/{id:int}")]

        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var result = await _bookingService.ReturnPrice(id);
            return Ok(result);
        }

        [HttpGet("getprice/{id:int}")]
        public async Task<IActionResult> GetPrices([FromRoute] int id)
        {
            var result=await _bookingService.ReturnPrice(id);
            return Ok(result);
        }

        [HttpGet("geteventbooking/{eventid:int}/{bookingid:int}")]
        public async Task<IActionResult> GetEventBooking([FromRoute] int eventid,int bookingid)
        {
            var result = await _bookingService.GetConfirmation(eventid,bookingid);
            return Ok(result);
        }



    }
}
