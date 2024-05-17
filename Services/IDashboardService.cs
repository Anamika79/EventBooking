using TicketBooking.Models;

namespace TicketBooking.Services
{
   
        public interface IDashboardService
        {
            Task<IEnumerable<Category>> GetCategoriesAsync();
            Task<IEnumerable<Event>> GetEventsAsync();

        }
    
}
