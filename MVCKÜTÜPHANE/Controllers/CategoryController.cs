using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKÜTÜPHANE.Controllers

{
    public class CategoryController : Controller
    {
        // GET: Category
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index(int syf=1)
        {
            var degerler = db.Tbl_Category.Where(x=>x.Durum==true).ToList().ToPagedList(syf, 4);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategoriEkle(Tbl_Category k)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategoriEkle");
            }
            db.Tbl_Category.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktgr = db.Tbl_Category.Find(id);
            // db.Tbl_Category.Remove(ktgr);
            ktgr.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var gtr = db.Tbl_Category.Find(id);
            return View("KategoriGetir", gtr);

        }

        public ActionResult KategoriGüncelle(Tbl_Category kt)
        {
            var gncl = db.Tbl_Category.Find(kt.CategoryID);
            gncl.AD = kt.AD;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}