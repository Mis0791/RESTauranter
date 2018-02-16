using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;

        public HomeController(RestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpPost]
        [Route("addReview")]
        public IActionResult addReview(Rest rest)
        {
            if(ModelState.IsValid)
            {
                _context.Add(rest);
                _context.SaveChanges();
                return RedirectToAction("showreviews");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("showreviews")]
        public IActionResult showReviews()
        {
            List<Rest> allReviews = _context.review.ToList();
            return View("Review", allReviews);
        }
    }
}
