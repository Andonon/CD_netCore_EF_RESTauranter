using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RESTauranter.Models;
using System.Linq;

namespace RESTauranter.Controllers

{
    public class HomeController : Controller
    {
        private ReviewContext _context;

        public HomeController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {

            List<Review> AllReviews = _context.reviews.ToList();
            ViewBag.AllReviews = AllReviews;
            return View();
        }

        [HttpGet]
        [Route("/reviews")]
        public IActionResult ViewReviews()
        {

            List<Review> AllReviews = _context.reviews.ToList();
            AllReviews.OrderByDescending(x => x.dateofvisit);
            ViewBag.AllReviews = AllReviews;
            return View("reviews");
        }

        [HttpPost]
        [Route("addreview")]
        public IActionResult AddReview(CreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                Review NewReview = new Review
                {
                    reviewer = model.reviewer,
                    restaurant = model.restaurant,
                    review = model.review,
                    dateofvisit = model.dateofvisit,
                    stars = model.stars, 
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                };
                _context.Add(NewReview);
                _context.SaveChanges();
                List<Review> AllReviews = _context.reviews.ToList();
                AllReviews.OrderByDescending(x => x.dateofvisit);
                ViewBag.AllReviews = AllReviews;
            } else {
                return View("index");
            }
            return View("reviews");
        }
    }
}
