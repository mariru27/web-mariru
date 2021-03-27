using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Hotel
    {
        [Key]
        public int IdHotel { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
    }
}
