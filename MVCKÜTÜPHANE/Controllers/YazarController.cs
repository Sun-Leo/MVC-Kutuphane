using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index(string y)
        {
            var yazar = from yz in db.Tbl_Yazar select yz;
            if (!string.IsNullOrEmpty(y))
            {
                yazar = yazar.Where(z => z.AD.Contains(y));
            }
            return View(yazar.ToList());
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(Tbl_Yazar y)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            var yzr = db.Tbl_Yazar.Add(y);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarSil(int id)
        {
            var yzrsil = db.Tbl_Yazar.Find(id);
            db.Tbl_Yazar.Remove(yzrsil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult YazarGüncelle(int id)
        {
            var yzr=db.Tbl_Yazar.Find(id);
            return View("YazarGüncelle",yzr);
        }
        [HttpPost]
        public ActionResult YazarGüncelle(Tbl_Yazar yz)
        {
            var yzrgün = db.Tbl_Yazar.Find(yz.YazarID);
            yzrgün.AD = yz.AD;
            yzrgün.SOYAD = yz.SOYAD;
            yzrgün.Detay = yz.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarınKitapları(int id)
        {
            var yazar = db.Tbl_Kitap.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.Tbl_Yazar.Where(y => y.YazarID == id).Select(y => y.AD + " " + y.SOYAD).FirstOrDefault();
            ViewBag.yzad = yzrad;
            return View(yazar);
            
        }


    }
}