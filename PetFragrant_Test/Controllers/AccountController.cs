using Microsoft.AspNetCore.Mvc;
using PetFragrant_Test.Data;
using PetFragrant_Test.Interface;
using PetFragrant_Test.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using CoreMvc5_CookieAuthentication.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Net.Sockets;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using System;
using CoreMvc5_CookieAuthentication.ViewModels;
using petsFragrant.Models;

namespace PetFragrant_Test.Controllers
{
    public class AccountController : Controller
    {
        private readonly PetContext _ctx;
        private readonly IHashService _hashService;

        public AccountController(PetContext ctx, IHashService hashService)
        {
            _ctx = ctx;
            _hashService = hashService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel logvVM)
        {
            if(ModelState.IsValid) { 
            
            ApplicationUser user = await AuthenticateUser(logvVM);

            // fail
            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "帳號或密碼有誤");
                return View(logvVM);
            }
            
            //成功，通過帳比對，以下開始建立授權
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("IsAdmin", user.IsAdmin.ToString(), ClaimValueTypes.Boolean )
                    //new Claim(ClaimTypes, user.IsAdmin) // 如果要有「群組、角色、權限」，可以加入這一段  
                };
            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
          
            };
            await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   authProperties
                   );

            return LocalRedirect("~/Report/SalesReport");
            }
            return View(logvVM);
        }

        private async Task<ApplicationUser> AuthenticateUser(LoginViewModel loginVM)
        {
            var user = await _ctx.Customers
                .FirstOrDefaultAsync(u => u.Email == loginVM.UserEmail &&  u.Password == _hashService.MD5Hash(loginVM.Password));
               
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                Customer user = new Customer
                {
                    CustomerID = Guid.NewGuid().ToString(),
                    CustomerName = registerVM.UserName,
                    Password = _hashService.MD5Hash(registerVM.Password),
                    PhoneNumber = registerVM.PhoneNumber,
                    Email = registerVM.Email,
                    Birthday = registerVM.Birthdate,
                    Address = registerVM.Address,
                    IsAdmin = false
                };

                _ctx.Customers.Add(user);
                _ctx.SaveChanges();

                ViewData["Title"] = "帳號註冊";
                ViewData["Message"] = "使用者帳號註冊成功!";  //顯示訊息

                return View("~/Views/Shared/ResultMessage.cshtml");

            }
            return View();
        }

        //登出
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }

        public IActionResult Forbidden()
        {
            return View();
        }

    }
}
