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
    public class ImmoController : Controller
    {
        private readonly ApplicationContext _context;

        public ImmoController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Immo
        public async Task<IActionResult> Index(string searchField)
        {
            var immos = from f in _context.Immo
                        orderby f.naam
                        select f;
            if (!string.IsNullOrEmpty(searchField))
                immos = from f in immos
                        where f.naam.Contains(searchField)
                        orderby f.naam
                        select f;

              return View(await immos.ToListAsync());
        }

        // GET: Immo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Immo == null)
            {
                return NotFound();
            }

            var immo = await _context.Immo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immo == null)
            {
                return NotFound();
            }

            return View(immo);
        }

        // GET: Immo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Immo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,naam,straat,description,huisnummer,gemeente,prijs,bouwjaar,kamers,grootte,tuin,type")] Immo immo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(immo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(immo);
        }

        // GET: Immo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Immo == null)
            {
                return NotFound();
            }

            var immo = await _context.Immo.FindAsync(id);
            if (immo == null)
            {
                return NotFound();
            }
            return View(immo);
        }

        // POST: Immo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,naam,straat,description,huisnummer,gemeente,prijs,bouwjaar,kamers,grootte,tuin,type")] Immo immo)
        {
            if (id != immo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(immo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImmoExists(immo.Id))
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
            return View(immo);
        }

        // GET: Immo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Immo == null)
            {
                return NotFound();
            }

            var immo = await _context.Immo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (immo == null)
            {
                return NotFound();
            }

            return View(immo);
        }

        // POST: Immo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Immo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Immo'  is null.");
            }
            var immo = await _context.Immo.FindAsync(id);
            if (immo != null)
            {
                immo.diseappear = true;
               // Immo.Delete = DateTime.Now;
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImmoExists(int id)
        {
          return _context.Immo.Any(e => e.Id == id);
        }
    }
}
