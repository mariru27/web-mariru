using ITEC_WebApp.Models;

namespace ITEC_WebApp.ViewModel
{
    public class SearchResult
    {
        public Country Country { get; set; }
        public City City { get; set; }
        public Hotel Hotel { get; set; }
        public Weather Weather { get; set; }
        public Covid Covid { get; set; }
        public Room Room { get; set; }
    }
}

