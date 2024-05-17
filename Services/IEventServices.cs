using TicketBooking.DTO;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IEventServices
    {
        Task<string> AddNewEventAsync(AddEventDTO ev);

        Task<List<Location>> GetLocations();

        Task<List<OrganiserEventListDTO>> GetOrganiserEventListAsync(int i);
        Task<List<Category>> GetCategories();

        Task<string> EditEventDetailAsync(EventUpdateDTO eventUpdate);

        Task<EventUpdateDTO> GetEditEventAsync(int id);

        Task<OrganiserDashDTO> GetDashValue(int id);

        Task<Event> GetEvent(int id);

    }
}
