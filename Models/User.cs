using System.ComponentModel.DataAnnotations;

namespace TicketBooking.Model
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string HashedPassword { get; set; }

        public string Role {  get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public string Mobile {  get; set; }

    }
}
