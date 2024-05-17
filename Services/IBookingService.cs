using TicketBooking.DTO;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IBookingService
    {
        Task<string> AddNewUserEventBooking(EventBooking eventBooking);
        Task<PriceDTO> ReturnPrice(int id);

        Task<ConfirmDTO> GetConfirmation(int eventid, int bookingid);
    }
}
