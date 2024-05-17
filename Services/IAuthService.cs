using TicketBooking.Models;

namespace TicketBooking.Services
{
    public interface IAuthService
    {
        Task<(RegisterResult, string)> UserLogin(LoginUserDto obj);
        Task<RegisterResult> UserRegister(RegisterUserDto usr);

    }
}
