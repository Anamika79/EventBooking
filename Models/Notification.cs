namespace TicketBooking.Models
{
    public class Notification
    {
        public int NotificationID { get; set; }

        public int EventID { get; set; }    

        public string NotficationTitle { get; set; }

        public string NotficationDescription { get; set; }

        public bool NotficationStatus { get; set; }

        public DateTime NotificationDate {  get; set; }
    }
}
