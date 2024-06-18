using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NZWalkes.API.Models.DTOs
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote(action: "IsEmailAvailable", controller: "Account")]  // remote validation attribute
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }
    }
}
