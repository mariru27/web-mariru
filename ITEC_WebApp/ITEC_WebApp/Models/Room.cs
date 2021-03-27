using System;

namespace ITEC_WebApp.Models
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string Description { get; set; }

    }
}
