using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public Role Role { get; set; }
        public List<Country> Countries { get; set; }

    }
}
