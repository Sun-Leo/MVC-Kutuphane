using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class MemberPanelController : Controller
    {
        DBKütüphaneEntities db=new DBKütüphaneEntities();
        // GET: MemberPanel
        [HttpGet]
        [Authorize]

        public ActionResult Index()
        {
            var üyemail = (string)Session["Mail"];
            var deger = db.Tbl_Üye.FirstOrDefault(x => x.MAİL == üyemail);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Index2(Tbl_Üye p)
        {
            var kullanıcı = (string)Session["Mail"];
            var üye = db.Tbl_Üye.FirstOrDefault(x => x.MAİL == kullanıcı);
            üye.ŞİFRE = p.ŞİFRE;
            üye.AD = p.AD;
            üye.SOYAD = p.SOYAD;
            üye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarım()
        {
            var kullanıcı = (string)Session["Mail"];
            var id=db.Tbl_Üye.Where(x=>x.MAİL==kullanıcı.ToString()).Select(y=>y.ÜyeID).FirstOrDefault();
            var değer = db.Tbl_Hareket.Where(x => x.AlanÜye==id).ToList();
            return View(değer);
        }

    }
}