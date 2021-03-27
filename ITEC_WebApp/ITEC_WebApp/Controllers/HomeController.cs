using ITEC_WebApp.Data;
using ITEC_WebApp.Models;
using ITEC_WebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public IActionResult Search(SearchModel searchModel)
        {
            //if (searchModel.CheckIn != null || searchModel.CheckOut != null || searchModel.City != null || searchModel.Country != null)
            //{

            //}
            return View();
        }

        public IActionResult Filter()
        {
            return View();
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
