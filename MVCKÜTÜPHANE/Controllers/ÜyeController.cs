using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKÜTÜPHANE.Controllers
{
    public class ÜyeController : Controller
    {
        // GET: Üye
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            var deger = db.Tbl_Üye.ToList().ToPagedList(sayfa, 4);
            return View(deger);
 
        }

        [HttpGet]
        public ActionResult ÜyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÜyeEkle(Tbl_Üye p)
        {
            if (!ModelState.IsValid)
            {
                return View("ÜyeEkle");
            }
            db.Tbl_Üye.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeSil(int id)
        {
            var üye = db.Tbl_Üye.Find(id);
            db.Tbl_Üye.Remove(üye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ÜyeGetir(int id)
        {
            var üye1 = db.Tbl_Üye.Find(id);
            return View("ÜyeGetir", üye1);
        }

        public ActionResult ÜyeGüncelle(Tbl_Üye ü)
        {
            var üye2 = db.Tbl_Üye.Find(ü.ÜyeID);
            üye2.AD = ü.AD;
            üye2.SOYAD = ü.SOYAD;
            üye2.MAİL = ü.MAİL;
            üye2.KULLANICIADI = ü.KULLANICIADI;
            üye2.ŞİFRE = ü.ŞİFRE;
            üye2.FOTOĞRAF = ü.FOTOĞRAF;
            üye2.TELEFON = ü.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}