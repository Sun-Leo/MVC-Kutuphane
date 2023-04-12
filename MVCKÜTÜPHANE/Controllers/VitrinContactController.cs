using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class VitrinContactController : Controller
    {
        // GET: VitrinContact
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult İletişimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult İletişimEkle(Tbl_İletişim i)
        {
            db.Tbl_İletişim.Add(i);
            db.SaveChanges();
            return View();
        }
        
        
       

    }
}