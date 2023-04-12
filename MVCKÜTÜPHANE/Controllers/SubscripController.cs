using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class SubscripController : Controller
    {
        // GET: Subscrip
        DBKütüphaneEntities db = new DBKütüphaneEntities();

        
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult AddSubscriber()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSubscriber(Tbl_Abone abone)
        {
            db.Tbl_Abone.Add(abone);
            db.SaveChanges();
            return RedirectToAction("Index", "VitrinMainPage");
        }
    }
}