using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Regester
        DBKütüphaneEntities db=new DBKütüphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Üye ü)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.Tbl_Üye.Add(ü);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}