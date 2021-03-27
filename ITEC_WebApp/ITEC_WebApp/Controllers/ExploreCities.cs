using ITEC_WebApp.Data;
using ITEC_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ITEC_WebApp.Controllers
{
    public class ExploreCities : Controller
    {
        public readonly ContextITEC _context;
        public ExploreCities(ContextITEC context)
        {
            _context = context;
        }
        public IActionResult FindHotel(int id)
        {
            Country country = _context.Country.Where(c => c.IdCountry == id).SingleOrDefault();
            //var a = _context.Country.Join(_context.City,
            //    c => c.Cities,
            //    cy => cy.IdCity,
            //    (c, cy) => new City { Hotels = cy.Hotels, IdCity = cy.IdCity, Name = cy.Name, Weather = cy.Weather }
            //    );
            //_context.Country.Join(_context.City,
            //    a => a.IdCountry,
            //    b => b.Country.IdCountry)


            return View();
        }
    }
}
