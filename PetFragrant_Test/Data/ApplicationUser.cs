using PetFragrant_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Options;
using petsFragrant.Models;

namespace CoreMvc5_CookieAuthentication.Data
{
    public class ApplicationUser
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public bool IsAdmin { get; set; }
    }
}
