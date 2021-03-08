using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Pre_TPI_AppartRental.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Razor_Pre_TPI_AppartRental.Models;

namespace Razor_Pre_TPI_AppartRental.Controllers
{
    
    [Authorize]
    public class AppartementsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppartementsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Appartements
        public async Task<IActionResult> Index()
        {
            var userId = await GetCurrentUserId();
            var model = await _context.Appartements.Select(x =>
                new AppartementViewModel
                {
                    AppartementId = x.Id,
                    Title = x.Title,
                    Year = x.Year
                }).ToListAsync();
            foreach (var item in model)
            {
                var m = await _context.UserAppartements.FirstOrDefaultAsync(x =>
                    x.UserId == userId && x.AppartementId == item.AppartementId);
                if (m != null)
                {
                    item.InWishlist = true;
                    item.Rating = m.Rating;
                    item.Visited = m.Visited;
                }
            }
            return View(model);
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

        [HttpGet]
        public async Task<JsonResult> AddRemove(int id, int val)
        {
            int retval = -1;
            var userId = await GetCurrentUserId();
            if (val == 1)
            {
                // if a record exists in UserMovies that contains both the user’s
                // and movie’s Ids, then the movie is in the watchlist and can
                // be removed
                var movie = _context.UserAppartements.FirstOrDefault(x =>
                    x.AppartementId == id && x.UserId == userId);
                if (movie != null)
                {
                    _context.UserAppartements.Remove(movie);
                    retval = 0;
                }

            }
            else
            {
                // the movie is not currently in the watchlist, so we need to
                // build a new UserMovie object and add it to the database
                _context.UserAppartements.Add(
                    new UserAppartement
                    {
                        UserId = userId,
                        AppartementId = id,
                        Visited = false,
                        Rating = 0
                    }
                );
                retval = 1;
            }
            // now we can save the changes to the database
            await _context.SaveChangesAsync();
            // and our return value (-1, 0, or 1) back to the script that called
            // this method from the Index page
            return Json(retval);
        }
    }
}
