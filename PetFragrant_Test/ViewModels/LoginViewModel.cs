using System.ComponentModel.DataAnnotations;

namespace PetFragrant_Test.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="E-mail")]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
