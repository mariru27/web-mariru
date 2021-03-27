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
            return View();
        }
    }
}
