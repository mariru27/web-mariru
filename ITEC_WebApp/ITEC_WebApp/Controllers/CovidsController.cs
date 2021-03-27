using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITEC_WebApp.Data;
using ITEC_WebApp.Models;

namespace ITEC_WebApp.Controllers
{
    public class CovidsController : Controller
    {
        private readonly ContextITEC _context;

        public CovidsController(ContextITEC context)
        {
            _context = context;
        }

        // GET: Covids
        public async Task<IActionResult> Index()
        {
            var contextITEC = _context.Covid.Include(c => c.Country);
            return View(await contextITEC.ToListAsync());
        }

        // GET: Covids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid = await _context.Covid
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.IdCovid == id);
            if (covid == null)
            {
                return NotFound();
            }

            return View(covid);
        }

        // GET: Covids/Create
        public IActionResult Create()
        {
            ViewData["IdCovid"] = new SelectList(_context.Country, "IdCountry", "Name");
            return View();
        }

        // POST: Covids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCovid,ProcentageVaccination")] Covid covid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(covid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCovid"] = new SelectList(_context.Country, "IdCountry", "Name", covid.IdCovid);
            return View(covid);
        }

        // GET: Covids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid = await _context.Covid.FindAsync(id);
            if (covid == null)
            {
                return NotFound();
            }
            ViewData["IdCovid"] = new SelectList(_context.Country, "IdCountry", "Name", covid.IdCovid);
            return View(covid);
        }

        // POST: Covids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCovid,ProcentageVaccination")] Covid covid)
        {
            if (id != covid.IdCovid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(covid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CovidExists(covid.IdCovid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCovid"] = new SelectList(_context.Country, "IdCountry", "Name", covid.IdCovid);
            return View(covid);
        }

        // GET: Covids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covid = await _context.Covid
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.IdCovid == id);
            if (covid == null)
            {
                return NotFound();
            }

            return View(covid);
        }

        // POST: Covids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var covid = await _context.Covid.FindAsync(id);
            _context.Covid.Remove(covid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CovidExists(int id)
        {
            return _context.Covid.Any(e => e.IdCovid == id);
        }
    }
}
