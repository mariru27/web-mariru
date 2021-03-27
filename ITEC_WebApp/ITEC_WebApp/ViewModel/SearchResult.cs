using ITEC_WebApp.Models;
using System.Collections.Generic;

namespace ITEC_WebApp.ViewModel
{
    public class SearchResult
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public Hotel Hotel { get; set; }
        public List<Room> Rooms { get; set; }
    }
}

