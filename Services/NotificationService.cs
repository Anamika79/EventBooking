using Microsoft.EntityFrameworkCore;
using TicketBooking.Data;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public class NotificationService:INotificationService
    {
        private readonly ApplicationDBContext _dBContext;
        public NotificationService(ApplicationDBContext dBContext) 
        { 
            _dBContext = dBContext;
        }

        public async Task<string> AddNewNotification(Notification noti)
        {
            try
            {
                await _dBContext.Notifications.AddAsync(noti);
                await _dBContext.SaveChangesAsync();
                return "good";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Notification>> GetNotifications(int id)
        {
            var results = await _dBContext.EventBookings
                                .Where(x => x.UserID == id)
                                .Select(x => x.EventID)
                                .ToListAsync();

            List<Notification> result = new List<Notification>();

            if (results.Any())
            {

                foreach (var item in results)

                    result.AddRange(await _dBContext.Notifications.Where(n => n.EventID == item).ToListAsync());

                return result;
            }

            else
                return null;
            
        }
    }
}
