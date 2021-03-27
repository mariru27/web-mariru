using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ITEC_WebApp.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string NameRole { get; set; }
        public List<User> Users { get; set; }
    }
}
