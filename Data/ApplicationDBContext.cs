using Microsoft.EntityFrameworkCore;
using TicketBooking.Model;
using TicketBooking.Models;

namespace TicketBooking.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<EventBooking> EventBookings { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Location>Locations { get; set; }

        public DbSet<Seating> Seatings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}
