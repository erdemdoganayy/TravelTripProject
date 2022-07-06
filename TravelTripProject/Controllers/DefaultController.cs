using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context db = new Context();
        public ActionResult Index()
        {
            var slider = db.Blogs.ToList();
            return View(slider);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public PartialViewResult PartialBlog()
        {
            var PartialBlog = db.Blogs.Take(3).OrderByDescending(x => x.Id).ToList();
            return PartialView(PartialBlog);
        }

    }
}