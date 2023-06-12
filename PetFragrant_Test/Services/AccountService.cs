using CoreMvc5_CookieAuthentication.Data;
using Microsoft.EntityFrameworkCore;
using PetFragrant_Test.Data;
using PetFragrant_Test.ViewModels;
using System.Threading.Tasks;

namespace PetFragrant_Test.Services
{
    public class AccountService
    {
        private readonly PetContext _ctx;

        public AccountService(PetContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ApplicationUser> AuthenticateUser(LoginViewModel loginVM)
        {
            var user = await _ctx.Customers
                .FirstOrDefaultAsync(u => u.Email == loginVM.UserEmail && u.Password == loginVM.Password);

            if (user != null)
            {


                var userInfo = new ApplicationUser
                {
                    Name = user.CustomerName,
                    Email = user.Email,
                    PhoneNo = user.PhoneNumber,
                    IsAdmin = user.IsAdmin
                };
                return userInfo;
            }
            else
            {
                return null;
            }
        }
    }
}