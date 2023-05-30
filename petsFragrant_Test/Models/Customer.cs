using System;
using System.ComponentModel.DataAnnotations;

namespace petsFragrant_Test.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Level { get; set; }
        public DateTime Birthday { get; set; }

    }
}
