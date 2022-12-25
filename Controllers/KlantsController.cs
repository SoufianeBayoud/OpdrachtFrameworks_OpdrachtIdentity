using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpdrachtFrameworks.Data;
using OpdrachtFrameworks.Models;

namespace OpdrachtFrameworks.Controllers
{
    public class KlantsController : Controller
    {
        private readonly ApplicationContext _context;

        public KlantsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Klants
        public async Task<IActionResult> Index(string searchField)
        {
            var klant = from f in _context.Klant
                        orderby f.naam
                        select f;
            if (!string.IsNullOrEmpty(searchField))
                klant = from f in klant
                        where f.naam.Contains(searchField)
                        orderby f.naam
                        select f;
            return View(await klant.ToListAsync());
        }

        // GET: Klants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Klant == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // GET: Klants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naam,straat,huisnummer,email")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klant);
        }

        // GET: Klants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Klant == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant.FindAsync(id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Klants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,naam,straat,huisnummer,email")] Klant klant)
        {
            if (id != klant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.Id))
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
            return View(klant);
        }

        // GET: Klants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Klant == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Klants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Klant == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Klant'  is null.");
            }
            var klant = await _context.Klant.FindAsync(id);
            if (klant != null)
            {
                klant.diseappear = true;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(int id)
        {
          return _context.Klant.Any(e => e.Id == id);
        }
    }
}
