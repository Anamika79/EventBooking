using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using TicketBooking.DTO;
using TicketBooking.Models;
using TicketBooking.Services;

namespace TicketBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventServices _eventServices;
        private readonly INotificationService _notiService;
        public EventController(IEventServices eventServices, INotificationService notiService )
        {

            _eventServices = eventServices;
            _notiService = notiService;
        }

        [HttpPost("addevent")]
        public async Task<IActionResult> AddEvent([FromBody] AddEventDTO ev)
        {
            try
            {
                if (ev == null) 
                {
                    return BadRequest("No Value Received");
                }
                else
                {
                    var res=await _eventServices.AddNewEventAsync(ev);
                 
                    return Ok(new {message= "Added Successfully" });

                   
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                return Ok(await _eventServices.GetCategories());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getlocations")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                return Ok(await _eventServices.GetLocations());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("organisereventlist/{id:int}")]
        public async Task<IActionResult> GetOrgniserList([FromRoute] int id)
        {
            try
            {
                var result = await _eventServices.GetOrganiserEventListAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("updateevent")]
        
        public async Task<IActionResult> UpdateOrganisedList([FromBody]EventUpdateDTO evnt)
        {   
            try
            {
               await _eventServices.EditEventDetailAsync(evnt);

                return Ok("Success");
                 
            }catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
            
        }

        [HttpGet("seteventupdateform/{id:int}")]
        public async Task<IActionResult> SetEventUpdateForm([FromRoute]int id)
        {
            var result =  await _eventServices.GetEditEventAsync(id);
            return Ok(result);
        }

        [HttpGet("getorgdash/{id:int}")]

        public async Task<IActionResult> GetOrganiserDash([FromRoute] int id)
        {
            var result = await _eventServices.GetDashValue(id);
            return Ok(result);
        }

        [HttpPost("addnotification")]

        public async Task<IActionResult> AddNotification([FromBody] Notification noti)
        {
            return Ok(await _notiService.AddNewNotification(noti));
        }

        [HttpGet("getevent/{id:int}")]

        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            var result = await _eventServices.GetEvent(id);
            return Ok(result);
        }



    }
}
