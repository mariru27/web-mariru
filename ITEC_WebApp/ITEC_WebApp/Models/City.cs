﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class City
    {
        [Key]
        public int IdCity { get; set; }
        [Required]
        [Display(Name = "City Name")]
        public string Name { get; set; }
        public Weather Weather { get; set; }
        public List<Hotel> Hotels { get; set; }
        public Country Country { get; set; }

    }
}
