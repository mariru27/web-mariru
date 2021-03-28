using ITEC_WebApp.Data;
using ITEC_WebApp.Models;
using ITEC_WebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ITEC_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ContextITEC _context;

        public HomeController(ILogger<HomeController> logger, ContextITEC context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Filter(SearchModel searchModel)
        {
            List<Room> rooms = new List<Room>();
            DateTime date = new DateTime();
            if (searchModel.CheckOut != null && searchModel.CheckIn != null)
            {
                rooms = _context.Room.Where(a => a.CheckIn <= searchModel.CheckIn && a.CheckOut >= searchModel.CheckOut).ToList();
            }
            else
            {
                if (searchModel.CheckIn != date)
                {
                    rooms = _context.Room.Where(a => a.CheckOut >= searchModel.CheckOut).ToList();

                }
                if (searchModel.CheckOut != date)
                {
                    rooms = _context.Room.Where(a => a.CheckIn <= searchModel.CheckIn).ToList();

                }
            }


            List<SearchResult> searchResults = new List<SearchResult>();
            foreach (var room in rooms)
            {
                SearchResult searchResult = new SearchResult();
                searchResult.Room = room;

                searchResult.Hotel = _context.Room.Where(a => a.IdRoom == searchResult.Room.IdRoom).Join(_context.Hotel,
                    a => a.Hotel.IdHotel,
                    b => b.IdHotel,
                    (a, b) => new Hotel { City = b.City, Description = b.Description, IdHotel = b.IdHotel, Rooms = b.Rooms, Name = b.Name, Stars = b.Stars }).SingleOrDefault();


                searchResult.City = _context.Hotel.Where(a => a.IdHotel == searchResult.Hotel.IdHotel).Join(_context.City,
                    a => a.City.IdCity,
                    b => b.IdCity,
                    (a, b) => new City { Country = b.Country, IdCity = b.IdCity, Hotels = b.Hotels, Name = b.Name, Weather = b.Weather }
                    ).SingleOrDefault();

                searchResult.Country = _context.City.Where(a => a.IdCity == searchResult.City.IdCity).Join(
                    _context.Country,
                    a => a.Country.IdCountry,
                    b => b.IdCountry,
                    (a, b) => new Country { IdCountry = b.IdCountry, Cities = b.Cities, Covid = b.Covid, Details = b.Details, Name = b.Name }).SingleOrDefault();

                searchResults.Add(searchResult);

            }

            return View(searchResults);

        }


        public async Task<IActionResult> Countries()
        {
            var a = _context.Country.Join(_context.Covid,
                a => a.IdCountry,
                b => b.Country.IdCountry,
                (a, b) => new Country { Cities = a.Cities, IdCountry = a.IdCountry, Covid = a.Covid, Details = a.Details, Name = a.Name }
                ).ToList();
            return View(await _context.Country.ToListAsync());
        }

        public IActionResult Cities(int id)
        {
            return View(_context.Country.Where(con => con.IdCountry == id).Join(_context.City,
                c => c.IdCountry,
                cy => cy.Country.IdCountry,
                (c, cy) => new City { Hotels = cy.Hotels, IdCity = cy.IdCity, Name = cy.Name, Weather = cy.Weather }
                ).ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
