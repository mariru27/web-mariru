using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
