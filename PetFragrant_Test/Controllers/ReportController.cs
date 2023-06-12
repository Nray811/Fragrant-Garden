using CoreMvc5_CookieAuthentication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetFragrant_Test.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult SalesReport()
        {
            return View();
        }

        [Authorize(Policy="IsAdmin" )]
        public IActionResult HRReport()
        {
            return View();
        }
    }
}
