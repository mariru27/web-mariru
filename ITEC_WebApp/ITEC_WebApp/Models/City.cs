using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class City
    {
        [Key]
        public int IdCity { get; set; }
        public string Name { get; set; }
        public Weather Weather { get; set; }
        public List<Hotel> Hotels { get; set; }

    }
}
