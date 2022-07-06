using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelTripProject.Models.Siniflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Blog> BlogsLastComment { get; set; }
        public IEnumerable<Yorumlar> Yorums { get; set;}
        public IEnumerable<Yorumlar> YorumsLastComment { get; set; }
    }
}