using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "lenght must be greater than 8 letter")]
        [Remote("CheckPassword", "Account", ErrorMessage = "Wrong Password Please enter correct password")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@(gmail\.com|yahoo\.com|outlook\.com|hotmail\.com)\b",
         ErrorMessage = "pleas enter valid email ")]
        [Remote("CheckEmial", "Account", ErrorMessage = "You are not Register")]
        public string Email { get; set; }
        public bool Remmberme { get; set; }
    }
}
