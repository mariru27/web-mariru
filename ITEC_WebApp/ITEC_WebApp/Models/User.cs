using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public Role Role { get; set; }
        public List<Country> Countries { get; set; }

    }
}
