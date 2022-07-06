using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context db = new Context();
        BlogYorum BlogYorum = new BlogYorum();
        public ActionResult Index()
        {
            // var model = db.Blogs.ToList();
            BlogYorum.Blogs = db.Blogs.ToList();
            BlogYorum.BlogsLastComment = db.Blogs.Take(3).OrderByDescending(x => x.Id).ToList();
            BlogYorum.YorumsLastComment = db.Yorumlars.Take(4).OrderByDescending(x => x.Id).ToList();
            return View(BlogYorum);
        }


        public ActionResult BlogDetay(int id)
        {
            //var model = db.Blogs.Where(x => x.Id == id).ToList();
            BlogYorum.Blogs = db.Blogs.Where(x => x.Id == id).ToList();
            BlogYorum.Yorums = db.Yorumlars.Where(x => x.BlogId == id).ToList();
            return View(BlogYorum);
        }
    }
}