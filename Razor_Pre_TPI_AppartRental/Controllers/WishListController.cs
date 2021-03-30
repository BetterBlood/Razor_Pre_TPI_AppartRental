using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Razor_Pre_TPI_AppartRental.Data;
using Razor_Pre_TPI_AppartRental.Models;

namespace Razor_Pre_TPI_AppartRental.Controllers
{
    public class WishListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public WishListController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var id = await GetCurrentUserId();
            var userAppartements = _context.UserAppartements.Where(x => x.UserId == id);
            var model = userAppartements.Select(x => new AppartementViewModel
            {
                AppartementId = x.AppartementId,
                Title = x.Appartement.Title,
                Year = x.Appartement.Year,
                Visited = x.Visited,
                InWishlist = true,
                Rating = x.Rating
            }).ToList();

            return View(model);
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            return user?.Id;
        }

        [HttpGet]
        public async Task<JsonResult> VisitedOrNot(int appartId, int val)
        {
            int retval = -1;
            var userId = await GetCurrentUserId();

            if (val == 1)
            {
                var appart = _context.UserAppartements.FirstOrDefault(x => x.AppartementId == appartId && x.UserId == userId); // QUESTION : pourquoi c'est toujours null // réponse : j'avais un mauvais lien........
                if (appart != null)
                {
                    appart.Visited = false;
                    retval = 0;
                }
            }
            else
            {
                var appart = _context.UserAppartements.FirstOrDefault(x => x.AppartementId == appartId && x.UserId == userId);
                if (appart != null)
                {
                    appart.Visited = true;
                    retval = 1;
                }
            }

            // now we can save the changes to the database
            await _context.SaveChangesAsync();
            // and our return value (-1, 0, or 1) back to the script that called
            // this method from the Index page
            return Json(retval);
        }

        [HttpGet]
        public async Task<JsonResult> UpdateRate(int appartId, int val)
        {
            int retval = -1;
            var userId = await GetCurrentUserId();

            var userAppart = _context.UserAppartements.FirstOrDefault(x => x.AppartementId == appartId && x.UserId == userId);
            var appart = _context.Appartements.FirstOrDefault(x => x.Id == appartId);

            if (appart != null && userAppart != null)
            {
                if (val == 0)
                {
                    userAppart.Rating = appart.Rating - 1;
                }
                else
                {
                    userAppart.Rating = appart.Rating + 1;
                }
                
                retval = 0;
            }

            await _context.SaveChangesAsync();
            return Json(retval);
        }
    }
}
