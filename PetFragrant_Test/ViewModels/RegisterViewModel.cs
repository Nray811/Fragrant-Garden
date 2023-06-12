using System;
using System.ComponentModel.DataAnnotations;

namespace CoreMvc5_CookieAuthentication.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "使用者名稱")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "電話")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "地址")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "生日")]
        public DateTime Birthdate { get; set; }
        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "密碼確認")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
