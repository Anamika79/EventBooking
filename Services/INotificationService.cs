using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface INotificationService
    {
        Task<string> AddNewNotification(Notification noti);
    }
}
