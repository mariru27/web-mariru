using System;
using System.ComponentModel.DataAnnotations;

namespace ITEC_WebApp.Models
{
    public class Room
    {
        [Key]
        public int IdRoom { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Description { get; set; }
        public Hotel Hotel { get; set; }

    }
}
