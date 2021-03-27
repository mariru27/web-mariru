using System.Collections.Generic;
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
        public City City { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
