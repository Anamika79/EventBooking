using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using TicketBooking.Data;
using TicketBooking.DTO;
using TicketBooking.Model;
using TicketBooking.Models;


namespace TicketBooking.Services
{
    public class EventServices : IEventServices
    {
        private readonly ApplicationDBContext _dbContext;
        public EventServices(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<string> AddNewEventAsync(AddEventDTO evnt)
        {
            try

            {
                Event ev = new Event();
                Seating st = new Seating();

                ev.EventStartDate = DateTime.Now;
                ev.EventName = evnt.EventName;
                ev.EventDescription = evnt.EventDescription;
                ev.CategoryID = evnt.CategoryID;
                ev.EventEndDate = DateTime.Now;
                ev.EventDescription = evnt.EventDescription;
                ev.VenueName = evnt.VenueName;
                ev.UserID = evnt.UserID;
                ev.LocationID = evnt.LocationID;
                ev.EventLikes = 0;

                ev.EventImage = "https://cdn.pixabay.com/photo/2017/12/08/11/53/event-party-3005668_640.jpg";
                var res = await _dbContext.Events.AddAsync(ev);
                await _dbContext.SaveChangesAsync();

                st.EventID = ev.EventID;
                st.SeatingID = 0;
                st.PlatinumSeatPrice = evnt.PlatinumSeatPrice;
                st.GoldSeatPrice = evnt.GoldSeatPrice;
                st.SilverSeatPrice = evnt.SilverSeatPrice;
                st.PlatinumSeatBooked = 0;
                st.GoldSeatBooked = 0;
                st.SilverSeatBooked = 0;

                st.TotalPlatinumSeats = evnt.TotalPlatinumSeats;
                st.TotalGoldSeats = evnt.TotalGoldSeats;
                st.TotalSilverSeats = evnt.TotalSilverSeats;

                var result = await _dbContext.Seatings.AddAsync(st);
                await _dbContext.SaveChangesAsync();
                return "Success";
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                return await _dbContext.Categories
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Location>> GetLocations()
        {
            try
            {
                return await _dbContext.Locations
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrganiserEventListDTO>> GetOrganiserEventListAsync(int id)
        {
            try
            {
                var result = await _dbContext.Events
                    .Where(x => x.UserID == id)
                    .Select(x => new OrganiserEventListDTO
                    {
                        EventName = x.EventName,
                        EventDate = x.EventStartDate.ToString(),
                        EventVenue = x.VenueName,
                        EventID = x.EventID
                    })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> EditEventDetailAsync(EventUpdateDTO eventUpdate)

        {
            try
            {
                var eventEntity = await _dbContext.Events.FindAsync(eventUpdate.EventID);
                eventEntity.EventDescription = eventUpdate.EventDescription;
                eventEntity.VenueName = eventUpdate.VenueName;

                await _dbContext.SaveChangesAsync();

                return ("Success");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public async Task<EventUpdateDTO> GetEditEventAsync(int id)
        {
            try
            {
                var result = await _dbContext.Events
                                            .Where(x => x.EventID == id)
                                            .Select(x => new EventUpdateDTO
                                            {
                                                EventName = x.EventName,
                                                EventDescription = x.EventDescription,
                                                VenueName = x.VenueName,
                                                EventID = x.EventID
                                            })
                                            .FirstOrDefaultAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrganiserDashDTO> GetDashValue(int id)
        {
            try
            {
                int bookedSeatCount = await _dbContext.EventBookings
                .Where(x => x.EventID == id)
                .SumAsync(x => x.PlatinumSeatCount + x.GoldSeatCount + x.SilverSeatCount);
                int totalSeatCount = await _dbContext.Seatings
                    .Where(x => x.EventID == id)
                    .SumAsync(x => x.TotalPlatinumSeats + x.TotalGoldSeats + x.TotalSilverSeats);
                int revenue = await _dbContext.EventBookings
                    .Where(x => x.EventID == id)
                    .SumAsync(x => x.TotalPrice);
                int totalLike = await _dbContext.Events
                    .Where(x => x.EventID == id)
                    .SumAsync(x => x.EventLikes);

                var organizerDto = new OrganiserDashDTO
                {
                    TicketSold = bookedSeatCount,
                    RemainingTickets = totalSeatCount - bookedSeatCount,
                    TotalIncome = revenue,
                    TotalLike = totalLike
                };

                return organizerDto;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        public async Task<Event> GetEvent(int id)
        {
            return await _dbContext.Events.FindAsync(id);
        }
        

    }


}
