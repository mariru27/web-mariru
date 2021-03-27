using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string NameRole { get; set; }
    }
}
