namespace TicketBooking.DTO
{
    public class ConfirmDTO
    {
        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public int TotalPrice { get; set; }

        public int PlatTickets {get;set;}

        public int GoldTickets { get; set; }

        public int SilvTickets {  get; set; }

    }
    
}
