using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace canberra_food_a2.Controllers
{
    public class HomeController : Controller
    {
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
        public IActionResult Restaurants()
        {
            ViewData["Message"] = "This is your Restaurants page";

            return View();
        }
        public IActionResult Reviews()
        {
            ViewData["Message"] = "This is your Reviews page";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
