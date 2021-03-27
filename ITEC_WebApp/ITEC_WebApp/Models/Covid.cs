using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Covid
    {
        [Key]
        public int IdCovid { get; set; }
        [Required]
        [Display(Name = "Percentage of Vaccination")]
        public float ProcentageVaccination { get; set; }
        public Country Country { get; set; }
    }
}
