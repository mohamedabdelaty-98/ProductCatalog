using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.ViewModel
{
    public class RegisterAcountVm
    {
        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "lenght must be greater than 8 letter")]
        [Remote("CheckPassword", "Account", ErrorMessage = "Must contain uppercase, lowercase,numbers and special charachter")]
        public string PasswordHash { get; set; }
        [Required]
        [Compare("PasswordHash", ErrorMessage = "Password Not Matched")]
        [DataType(DataType.Password)]
        public string ConfiremPassword { get; set; }
        [Required]
        [RegularExpression(@"^(010|011|015|012)\d{8}$", ErrorMessage = "Enter Valid PhoneNumber")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]+@(gmail\.com|yahoo\.com|outlook\.com|hotmail\.com)\b",
            ErrorMessage = "pleas enter valid email ")]
        //ckeckemail
        public string Email { get; set; }
    }
}
