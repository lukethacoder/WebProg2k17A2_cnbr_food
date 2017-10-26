using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using canberra_food_a2.Data;
using Microsoft.EntityFrameworkCore;


namespace canberra_food_a2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cuisine()
        {
            ViewData["Message"] = "This is your Cuisine page";

            return View();
        }

        public IActionResult Dishes()
        {
            ViewData["Message"] = "This is your Cuisine page";

            return View();
        }
        public IActionResult Location()
        {
            ViewData["Message"] = "This is your Location page";

            return View();
        }
        public IActionResult Price()
        {
            ViewData["Message"] = "This is your Price page";

            return View();
        }
        /* public IActionResult Restaurants()
        {
            ViewData["Message"] = "This is your Restaurants page";

            return View();
        } */
        public async Task<IActionResult> Restaurants()
        {
            ViewData["Message"] = "This is your restaurants page";

            return View(await _context.Rest_reviews.ToListAsync());
        }

        /* public IActionResult Reviews()
        {
            ViewData["Message"] = "This is your Reviews page";

            return View();
        } */

        public IActionResult Error()
        {
            return View();
        }
    }
}
