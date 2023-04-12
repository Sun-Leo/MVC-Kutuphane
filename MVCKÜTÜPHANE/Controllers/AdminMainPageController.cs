using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class AdminMainPageController : Controller
    {
        // GET: AdminMainPage
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        
        public ActionResult Index()
        {
            ViewBag.kitap = db.Tbl_Kitap.Count();
            ViewBag.üye = db.Tbl_Üye.Count();
            ViewBag.yazar = db.Tbl_Yazar.Count();
            ViewBag.ödünç = db.Tbl_Hareket.Where(x => x.İşlemDurum == false).Count();
            return View();
        }
    }
}