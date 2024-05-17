using Microsoft.EntityFrameworkCore;
using TicketBooking.Data;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public class DashboardService:IDashboardService
    {
        private readonly ApplicationDBContext _dbContext;
        

        public DashboardService(ApplicationDBContext context)
        {
            _dbContext = context;
        }



        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _dbContext.Categories.ToListAsync();
                return categories;
            }

            catch (Exception ex) { 
                return Enumerable.Empty<Category>();
            }
            
        }

        public async Task<IEnumerable<Event>> GetEventsAsync()
        {
            try
            {
                var events = await _dbContext.Events.ToListAsync();
                return events;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Event>();
            }
            
        }
    }
}
