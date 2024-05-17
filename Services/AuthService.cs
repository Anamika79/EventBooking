using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using TicketBooking.Data;
using TicketBooking.Model;
using TicketBooking.Models;
using TicketBooking.Helper;
using Microsoft.EntityFrameworkCore;

namespace TicketBooking.Services
{
    
        public enum RegisterResult
        {
            RegisterSuccess,
            EmailAlreadyExists,
            WeakPassword,
            LoginSuccess,
            UserNotFound,
            WrongPassword,
            NullUser
        }
        public class AuthService : IAuthService
        {
            private readonly ApplicationDBContext _dbContext;
            private readonly IConfiguration _configuration;

            public AuthService(ApplicationDBContext dbContext, IConfiguration configuration)
            {
                _dbContext = dbContext;
                _configuration = configuration;
            }

            public async Task<(RegisterResult, string)> UserLogin(LoginUserDto obj)
            {
                var usr = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == obj.Email);
                if (usr == null)
                {
                    return (RegisterResult.UserNotFound, null);
                }
                if (!PasswordHasher.VerifyPassword(obj.Password, usr.HashedPassword))
                {
                    return (RegisterResult.WrongPassword, null);
                }

                // Token generation
                var token = CreateJwt(usr);

                return (RegisterResult.LoginSuccess, token);
            }

            public async Task<RegisterResult> UserRegister(RegisterUserDto usr)
            {
                if (usr == null)
                    return RegisterResult.NullUser;

                // Check email existence
                if (await CheckEmailExistAsync(usr.Email))
                    return RegisterResult.EmailAlreadyExists;

                // Check password strength
                var password = CheckPasswordStrength(usr.Password);
                if (!string.IsNullOrEmpty(password))
                {
                    return RegisterResult.WeakPassword;
                }

                User user = new User();

                user.FullName = usr.FullName;
                user.Email = usr.Email;
                user.Mobile = usr.Mobile;
                user.CreatedDate = DateTime.Now;
                user.Status = "Verified";
                user.Role = usr.Role;

                user.HashedPassword = PasswordHasher.HashPassword(usr.Password);
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return RegisterResult.RegisterSuccess;
            }

            private async Task<bool> CheckEmailExistAsync(string email)
            {
                return await _dbContext.Users.AnyAsync(x => x.Email == email);
            }

            private string CheckPasswordStrength(string password)
            {
                StringBuilder sb = new StringBuilder();
                if (password.Length < 8)
                {
                    sb.Append("Minimum password length should be 8" + Environment.NewLine);
                }
                if (!(Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]")
        && Regex.IsMatch(password, "[0-9]")))
                {
                    sb.Append("Password should be alphanumeric" + Environment.NewLine);
                }
                return sb.ToString();
            }

            private string CreateJwt(User user)
            {
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("veryveryverysecret...");
                var identity = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Name,$"{user.UserID}")
                });
                var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = identity,
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = credentials
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                return jwtTokenHandler.WriteToken(token);
            }

        }
    
}
