using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Pre_TPI_AppartRental.Data;

namespace Razor_Pre_TPI_AppartRental.Controllers
{
    public class AppartementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppartementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appartements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appartements.ToListAsync());
        }

        // GET: Appartements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appartement = await _context.Appartements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appartement == null)
            {
                return NotFound();
            }

            return View(appartement);
        }

        // GET: Appartements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appartements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Year,Surface")] Appartement appartement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appartement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appartement);
        }

        // GET: Appartements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appartement = await _context.Appartements.FindAsync(id);
            if (appartement == null)
            {
                return NotFound();
            }
            return View(appartement);
        }

        // POST: Appartements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Year,Surface")] Appartement appartement)
        {
            if (id != appartement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appartement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppartementExists(appartement.Id))
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
            return View(appartement);
        }

        // GET: Appartements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appartement = await _context.Appartements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appartement == null)
            {
                return NotFound();
            }

            return View(appartement);
        }

        // POST: Appartements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appartement = await _context.Appartements.FindAsync(id);
            _context.Appartements.Remove(appartement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppartementExists(int id)
        {
            return _context.Appartements.Any(e => e.Id == id);
        }
    }
}
