using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class VitrinMainPageController : Controller
    {
        // GET: VitrinMainPage
        DBKütüphaneEntities db = new DBKütüphaneEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult PartialWrapper()
        {
            ViewBag.kaşağı = db.Tbl_Kitap.Where(x => x.KitapID == 3).Select(x => x.KitapFoto).FirstOrDefault();
            return PartialView();
        }
        
        public PartialViewResult PartialFooter()
        {
                      
            return PartialView();
        }
      
    }
}