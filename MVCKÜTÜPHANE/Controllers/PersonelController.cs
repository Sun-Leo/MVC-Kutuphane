using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBKütüphaneEntities db = new DBKütüphaneEntities();

        public ActionResult Index(string p)
        {
            var personel = from pr in db.Tbl_Personel select pr;
            if (!string.IsNullOrEmpty(p))
            {
                personel = personel.Where(prs => prs.AD.Contains(p));
            }
            return View(personel.ToList());
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Tbl_Personel pr)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.Tbl_Personel.Add(pr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.Tbl_Personel.Find(id);
            db.Tbl_Personel.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public ActionResult PersonelGetir(int id)
        {
            var per = db.Tbl_Personel.Find(id);
            return View("PersonelGetir", per);
        }
      
        public ActionResult PersonelGüncelle(Tbl_Personel p)
        {
            var prs = db.Tbl_Personel.Find(p.PersonelID);
            prs.AD=p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}