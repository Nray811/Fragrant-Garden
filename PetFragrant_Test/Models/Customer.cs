using System;
using System.ComponentModel.DataAnnotations;

namespace petsFragrant.Models
{
    public class Customer
    {
        [Key]
        [Display(Name = "顧客ID")]
        public string CustomerID { get; set; }
        [Display(Name = "顧客姓名")]
        public string CustomerName { get; set; }
        [Display(Name = "是否為管理者")]
        public bool IsAdmin { get; set; }
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "電話")]
        public string PhoneNumber { get; set; }
        [Display(Name = "地址")]
        public string Address { get; set; }
        [Display(Name = "會員等級")]
        public string Level { get; set; }
        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

    }
}
