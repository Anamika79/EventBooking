using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Models
{
    public class EventBooking
    {
        [Key]
        public int BookingID { get; set; }
        public int EventID { get; set; }
        public int UserID { get; set; }
        public int PlatinumSeatCount { get; set; }
        public int GoldSeatCount { get; set; }
        public int SilverSeatCount { get; set; }
        public int TotalPrice { get; set; }

        public bool isConfirmed {  get; set; }

    }
}
