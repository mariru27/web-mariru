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
            var a = _context.Country.Where(con => con.IdCountry == id).Join(_context.City,
                c => c.IdCountry,
                cy => cy.Country.IdCountry,
                (c, cy) => new City { Hotels = cy.Hotels, IdCity = cy.IdCity, Name = cy.Name, Weather = cy.Weather }
                ).ToList();





            return View(a);
        }
    }
}
