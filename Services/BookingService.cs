using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketBooking.Data;
using TicketBooking.DTO;
using TicketBooking.Model;
using TicketBooking.Models;

namespace TicketBooking.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDBContext _dbContext;
        public BookingService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddNewUserEventBooking(EventBooking eventBooking)
        {
            try
            {
                await _dbContext.EventBookings.AddAsync(eventBooking);
                await _dbContext.SaveChangesAsync();
                return ("Success");
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
        }

        public async Task<PriceDTO> ReturnPrice(int id)
        {
            var seating = _dbContext.Seatings.FirstOrDefault(s => s.EventID == id);

            if (seating != null)
            {
                var priceDto = new PriceDTO
                {
                    PlatinumPrice = seating.PlatinumSeatPrice,
                    GoldPrice = seating.GoldSeatPrice,
                    SilverPrice = seating.SilverSeatPrice
                };

                return priceDto;
            }

            else
                return null;
        }


        public async Task<ConfirmDTO> GetConfirmation(int eventid,int userid)
        {
            var ev=await _dbContext.Events.FirstOrDefaultAsync(x=>x.EventID == eventid);
            var st = await _dbContext.EventBookings
                                            .OrderBy(eb => eb.BookingID)
                                            .Where(eb => eb.UserID == userid)
                                            .LastOrDefaultAsync();

            var confirmDTO = new ConfirmDTO
            {
                EventDate=ev.EventStartDate,
                EventName=ev.EventName,
                GoldTickets=st.GoldSeatCount,
                SilvTickets=st.SilverSeatCount,
                PlatTickets=st.PlatinumSeatCount,
                TotalPrice=st.TotalPrice

            };
            return confirmDTO;
        }

       
    }
}
