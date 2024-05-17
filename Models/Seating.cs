using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;

namespace TicketBooking.Models
{
    public class Seating
    {
        [Key]
        public int SeatingID { get; set; }

        public int EventID { get; set; }
        
        public int TotalPlatinumSeats {  get; set; }

        public int TotalGoldSeats {  get; set; }

        public int TotalSilverSeats {  get; set; }

        public int PlatinumSeatPrice {  get; set; }

        public int GoldSeatPrice { get; set; }

        public int SilverSeatPrice { get; set; }

        public int PlatinumSeatBooked {  get; set; }

        public int GoldSeatBooked { get;set; }

        public int SilverSeatBooked { get; set; }

    }
}
