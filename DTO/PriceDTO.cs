using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketBooking.DTO
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceDTO : ControllerBase
    {
        public int PlatinumPrice { get; set; }

        public int GoldPrice { get; set; }

        public int SilverPrice { get; set; }
    }
}
