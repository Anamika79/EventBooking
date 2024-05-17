using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IAdminService
    {
        Task<string> AddLocationAsync(Location loc);
        Task<string> AddCategoryAsync(Category cat);
    }
}
