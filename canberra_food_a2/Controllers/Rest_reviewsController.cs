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
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rest_reviews);
        }

        // GET: Rest_reviews/Edit/5
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
                    /* Date = DateTime.Now.ToString(); */
                    /* DateTime.Now.ToString(); */
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rest_reviews = await _context.Rest_reviews.SingleOrDefaultAsync(m => m.Id == id);
            _context.Rest_reviews.Remove(rest_reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool Rest_reviewsExists(int id)
        {
            return _context.Rest_reviews.Any(e => e.Id == id);
        }
    }
}
