using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class ÖdünçController : Controller
    {
        // GET: Ödünç
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index()
        {
            var değerler = db.Tbl_Hareket.Where(x=>x.İşlemDurum==false).ToList();
            return View(değerler);
        }
        [HttpGet]
        public ActionResult ÖdünçVer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ÖdünçVer(Tbl_Hareket h)
        {
            db.Tbl_Hareket.Add(h);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitapİade(int id)
        {
            var iade = db.Tbl_Hareket.Find(id);
            return View("Kitapİade", iade);
        }
        public ActionResult İadeGüncelle(Tbl_Hareket p)
        {
            var value = db.Tbl_Hareket.Find(p.HareketID);
            value.ÜyeİadeTarihi = p.ÜyeİadeTarihi;
            value.İşlemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}