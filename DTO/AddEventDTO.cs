namespace TicketBooking.DTO
{
    public class AddEventDTO
    {

        public string VenueName { get; set; }

        public int LocationID { get; set; }

        public int CategoryID { get; set; }

        public int UserID { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventStartDate { get; set; }

        public DateTime EventEndDate { get; set; }

        public int TotalPlatinumSeats { get; set; }

        public int TotalGoldSeats { get; set; }

        public int TotalSilverSeats { get; set; }

        public int PlatinumSeatPrice { get; set; }

        public int GoldSeatPrice { get; set; }

        public int SilverSeatPrice { get; set; }

 
    }
}
