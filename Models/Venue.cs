using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Model
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }

        public int VenueName { get; set; }

        public int LocationID { get; set; }

        public int VenueType { get; set; }

        public int Capacity { get; set; }

        public int BookingPrice { get; set; }


    }
}
