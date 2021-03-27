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
            var a = _context.City.Where(con => con.IdCity == id).Join(_context.Hotel,
                c => c.IdCity,
                cy => cy.City.IdCity,
                (c, cy) => new Hotel { City = cy.City, Rooms = cy.Rooms, Name = cy.Name, Description = cy.Description, IdHotel = cy.IdHotel, Stars = cy.Stars }
                ).ToList();
            return View(a);
        }

        public IActionResult Rooms(int id)
        {
            var a = _context.Hotel.Where(a => a.IdHotel == id).Join(
                 _context.Room,
                 a => a.IdHotel,
                 b => b.Hotel.IdHotel,
                 (a, b) => new Hotel { City = a.City, Description = a.Description, IdHotel = a.IdHotel, Name = a.Name, Rooms = a.Rooms, Stars = a.Stars }).ToList();
            return View();
        }
    }
}
