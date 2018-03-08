using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppsLab5.Models;

namespace WebAppsLab5.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly WebAppsLab5Context _context;

        public ReviewsController(WebAppsLab5Context context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index(string sortby, string direction)
        {
            var reviews = from r in _context.Review
                          select r;


            if (sortby == "reviewer")
            {
                ViewData["ReviewerDirection"] = direction;
                ViewData["MovieDirection"] = "des";

                if (direction == "asc")
                {
                    reviews = reviews.OrderBy(r => r.Reviewer);

                } else
                {
                    reviews = reviews.OrderByDescending(r => r.Reviewer);
                }
            } else if(sortby == "movie")
            {
                ViewData["MovieDirection"] = direction;
                ViewData["ReviewerDirection"] = "des";

                if (direction == "asc")
                {
                    reviews = reviews.OrderBy(r => r.MovieTitle);
                }
                else
                {
                    reviews = reviews.OrderByDescending(r => r.MovieTitle);
                }
            }
            return View(await reviews.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        public IActionResult Create(int? id)
        {
            ViewData["Movie"] = _context.Movie
                .SingleOrDefault(m => m.ID == id);
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,Reviewer,Comment,MovieIden,MovieTitle")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Movies", new { id = review.MovieIden});
            }
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.SingleOrDefaultAsync(m => m.ReviewID == id);
            ViewData["Movie"] = await _context.Movie.SingleOrDefaultAsync(m => m.ID == review.MovieIden);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Reviewer,Comment,MovieIden,MovieTitle")] Review review)
        {
            if (id != review.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.ReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Movies", new { id = review.MovieIden});
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.ReviewID == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.ReviewID == id);
            int movieID = review.MovieIden;
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Movies", new { id = movieID});
        }

        private bool ReviewExists(int id)
        {
            return _context.Review.Any(e => e.ReviewID == id);
        }
    }
}
