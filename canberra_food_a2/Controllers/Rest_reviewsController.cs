using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using canberra_food_a2.Data;
using canberra_food_a2.Models;
using Microsoft.AspNetCore.Authorization;

// Sessions Code https://www.danylkoweb.com/Blog/how-to-make-your-own-real-time-like-button-using-aspnet-mvc-jquery-and-signalr-QF 
// add Authorise roles to individual pages (so 'users' cant access the link even with the url)

namespace canberra_food_a2.Controllers
{
    public class Rest_reviewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Rest_reviewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        // GET: Rest_reviews
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rest_reviews.ToListAsync());
        }

        // GET: Rest_reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rest_reviews = await _context.Rest_reviews
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rest_reviews == null)
            {
                return NotFound();
            }

            return View(rest_reviews);
        }

        // GET: Rest_reviews/Create
        [Authorize(Roles = "Manager, User")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rest_reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Heading,Comment,Restaurant,Rating")] Rest_reviews rest_reviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rest_reviews);
                rest_reviews.Date = DateTime.Now;
                rest_reviews.Agree = 0;
                rest_reviews.Disagree = 0;
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rest_reviews);
        }

        // GET: Rest_reviews/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rest_reviews = await _context.Rest_reviews.SingleOrDefaultAsync(m => m.Id == id);
            if (rest_reviews == null)
            {
                return NotFound();
            }
            return View(rest_reviews);
        }

        // POST: Rest_reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Heading,Comment,Restaurant,Rating")] Rest_reviews rest_reviews)
        {
            if (id != rest_reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rest_reviews);
                    rest_reviews.Date = DateTime.Now;
                    rest_reviews.Name = User.Identity.Name;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rest_reviewsExists(rest_reviews.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(rest_reviews);
        }

        // GET: Rest_reviews/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rest_reviews = await _context.Rest_reviews
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rest_reviews == null)
            {
                return NotFound();
            }

            return View(rest_reviews);
        }

        // POST: Rest_reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rest_reviews = await _context.Rest_reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Rest_reviews.Remove(rest_reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Increase agree value
        public async Task<IActionResult> AgreeIncrease(int id, [Bind("Id,Date,Name,Heading,Comment,Restaurant,Rating,Agree,Disagree")] Rest_reviews rest_reviews)
        {
            if (id != rest_reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rest_reviews);
                    rest_reviews.Agree = rest_reviews.Agree + 1;
                    /* rest_reviews.IsClicked = true; */
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rest_reviewsExists(rest_reviews.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(rest_reviews);
        }

        private bool Rest_reviewsExists(int id)
        {
            return _context.Rest_reviews.Any(e => e.Id == id);
        }
    }
}
