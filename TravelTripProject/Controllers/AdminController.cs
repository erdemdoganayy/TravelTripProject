using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Siniflar;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {

        Context db = new Context();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            var blogs = db.Blogs.ToList();
            return View(blogs);
        }
        [Authorize]
        [HttpGet]
        public ActionResult YeniBlogEkle()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniBlogEkle(Blog b)
        {
            if (b.Id != null && b.Baslik != null)
            {
                var result = db.Blogs.Add(b);
                db.SaveChanges();
                ViewData["success"] = "Kayıt Başarılı";
                return View();
            }
            else
            {
                ViewData["error"] = "Kayıt Başarısız";
                return View();
            }

        }
        public ActionResult BlogSil(int id)
        {
            if (id != null)
            {
                var result = db.Blogs.Find(id);
                db.Blogs.Remove(result);
                db.SaveChanges();
                TempData["success"] = "Success";
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["error"] = "Error";
                return RedirectToAction("Index", "Admin");

            }
        }
        [Authorize]
        public ActionResult BlogBilgiGetir(int id)
        {
            var GetData = db.Blogs.Find(id);
            return View("BlogBilgiGetir", GetData);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var result = db.Blogs.Where(x => x.Id == b.Id).FirstOrDefault();
            result.Baslik = b.Baslik;
            result.BlogImage = b.BlogImage;
            result.Aciklama = b.Aciklama;
            result.Tarih = b.Tarih;
            db.SaveChanges();
            TempData["success"] = "Güncelleme Başarılı !";
            return RedirectToAction("Index", "Admin");
        }
        [Authorize]
        public ActionResult Yorumlar()
        {
            var yorumlar = db.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumBilgiGetir(int id)
        {
            var yorum = db.Yorumlars.Find(id);
            return View(yorum);
        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            if (y.Yorum != null && y.KullaniciAdi != null)
            {
                var yorum = db.Yorumlars.Find(y.Id);
                yorum.KullaniciAdi = y.KullaniciAdi;
                yorum.Mail = y.Mail;
                yorum.Yorum = y.Yorum;
                db.SaveChanges();
                TempData["success"] = "Başarılı";
                return RedirectToAction("Yorumlar","Admin");
            }
            else
            {
                TempData["error"] = "Başarısız";
                return RedirectToAction("Yorumlar", "Admin");
            }
        }

        public ActionResult YorumSil(int id)
        {
            if(id != null)
            {
                var yorum = db.Yorumlars.Find(id);
                db.Yorumlars.Remove(yorum);
                db.SaveChanges();
                TempData["success"] = "Başarılı";
                return RedirectToAction("Yorumlar", "Admin");
            }
            else
            {
                TempData["error"] = "Başarısız";
                return RedirectToAction("Yorumlar", "Admin");
            }
        }


        public ActionResult Hakkimizda()
        {
            var hakkimizda = db.Hakkimizdas.FirstOrDefault();
            return View(hakkimizda);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda hak)
        {
            if (hak.Aciklama != null && hak.FotoUrl != null)
            {
                var hakkimizda = db.Hakkimizdas.Find(hak.Id);
                hakkimizda.Aciklama = hak.Aciklama;
                hakkimizda.FotoUrl = hak.FotoUrl;
                db.SaveChanges();
                TempData["success"] = "Başarılı";
                return RedirectToAction("Hakkimizda", "Admin");
            }
            else
            {
                TempData["error"] = "Başarısız";
                return RedirectToAction("Hakkimizda", "Admin");
            }

        }
    }
}