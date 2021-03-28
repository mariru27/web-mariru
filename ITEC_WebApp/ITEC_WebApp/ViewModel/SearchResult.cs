using ITEC_WebApp.Models;

namespace ITEC_WebApp.ViewModel
{
    public class SearchResult
    {
        public SearchResult()
        {

        }
        public SearchResult(SearchResult searchResult)
        {
            Country = searchResult.Country;
            City = searchResult.City;
            Hotel = searchResult.Hotel;
            Room = searchResult.Room;
        }
        public Country Country { get; set; }
        public City City { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}

