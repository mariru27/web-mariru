using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }



    }
}
