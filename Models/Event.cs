using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        public string VenueName{ get; set; }

        public int LocationID {  get; set; }
        
        public int CategoryID { get; set; }

        public int UserID {  get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventStartDate { get; set; }

        public DateTime EventEndDate { get; set; }

        public string EventImage {  get; set; }

        public int EventLikes {  get; set; }

     //   public bool IsConfirmed {  get; set; }

    }
}
