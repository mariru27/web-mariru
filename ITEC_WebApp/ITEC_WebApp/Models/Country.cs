﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }
        [Required]
        [Display(Name = "Country Name")]
        public string Name { get; set; }
        public string Details { get; set; }
        public Covid Covid { get; set; }

        public List<City> Cities { get; set; }


    }
}
