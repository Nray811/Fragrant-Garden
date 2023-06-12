using Microsoft.AspNetCore.Mvc;
using PetFragrant_Test.Models;
using PetFragrant_Test.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CoreMvc5_CookieAuthentication.Data;
using Microsoft.AspNetCore.Authorization;

namespace PetFragrant_Test.Controllers
{
    public class UserController : Controller
    {
        private readonly PetContext _ctx;
        public UserController(PetContext ctx)
        {
            _ctx = ctx;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var user = await _ctx.Customers
                  .FirstOrDefaultAsync(u => u.CustomerName == User.Identity.Name);
                var userInfo = new ApplicationUser
                {
                    Name = user.CustomerName,
                    Email = user.Email,
                    PhoneNo = user.PhoneNumber,
                    IsAdmin = user.IsAdmin
                };
                ViewBag.User = userInfo;
                return View(userInfo);
            }
            else
            {
                return null;
            }
        }
    }
}
