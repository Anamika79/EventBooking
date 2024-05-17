using TicketBooking.Data;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public class AdminService:IAdminService
    {

        private readonly ApplicationDBContext _dbContext;
        public AdminService(ApplicationDBContext dBContext) { 
            _dbContext = dBContext;
        }

        public async Task<string> AddLocationAsync(Location loc)
        {
            try
            {
                await _dbContext.Locations.AddAsync(loc);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public async Task<string> AddCategoryAsync(Category cat)
        {
            try
            {
                await _dbContext.Categories.AddAsync(cat);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
    }
}
