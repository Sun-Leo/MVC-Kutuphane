using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCKÜTÜPHANE.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.Tbl_Kitap select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(t => t.AD.Contains(p));
            }
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> list = (from i in db.Tbl_Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.AD,
                                             Value = i.CategoryID.ToString()
                                         }).ToList();
            ViewBag. list1 = list;

            List<SelectListItem> list2 = (from i in db.Tbl_Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD  + i.SOYAD,
                                              Value = i.YazarID.ToString()
                                          }).ToList();
            ViewBag.lst2 = list2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(Tbl_Kitap kt)
        {
            var ktg = db.Tbl_Category.Where(k => k.CategoryID == kt.Tbl_Category.CategoryID).FirstOrDefault();
            var yzr = db.Tbl_Yazar.Where(y => y.YazarID == kt.Tbl_Yazar.YazarID).FirstOrDefault();
            kt.Tbl_Category = ktg;
            kt.Tbl_Yazar = yzr;
            db.Tbl_Kitap.Add(kt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KitapSil(int id)
        {
            var ktpsil = db.Tbl_Kitap.Find(id);
            db.Tbl_Kitap.Remove(ktpsil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        //Güncellenecek bilgileri Güncelle butonuna tıkladığımızda otomatik getirmesi için
        public ActionResult KitapGetir(int id)
        {
            var ktp = db.Tbl_Kitap.Find(id);
            List<SelectListItem> list = (from i in db.Tbl_Category.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.AD,
                                             Value = i.CategoryID.ToString()
                                         }).ToList();
            ViewBag.lst1 = list;
            List<SelectListItem> list1 = (from i in db.Tbl_Yazar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD + i.SOYAD,
                                              Value = i.YazarID.ToString()

                                          }).ToList();
            ViewBag.lst2 = list1;
            return View("KitapGetir", ktp);
        }
        public ActionResult KitapGüncelle(Tbl_Kitap p)
        {
            var kitap = db.Tbl_Kitap.Find(p.KitapID);
            kitap.AD = p.AD;
            kitap.SAYFA= p.SAYFA;
            kitap.BASIMYILI = p.BASIMYILI;
            kitap.YAYINEVİ = p.YAYINEVİ;
            var ktg = db.Tbl_Category.Where(k => k.CategoryID == p.Tbl_Category.CategoryID).FirstOrDefault();
            var yzr = db.Tbl_Yazar.Where(y => y.YazarID == p.Tbl_Yazar.YazarID).FirstOrDefault();
            kitap.KATEGORİ = ktg.CategoryID;
            kitap.YAZAR = yzr.YazarID;
            db.SaveChanges();
            return RedirectToAction("Index","Kitap");
        }
    }
}