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
    }
}
