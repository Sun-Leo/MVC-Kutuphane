using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;

namespace MVCKÜTÜPHANE.Controllers
{
    public class İşlemlerController : Controller
    {
        // GET: İşlemler
        DBKütüphaneEntities db= new DBKütüphaneEntities();
        public ActionResult Index()
        {
            var değer= db.Tbl_Hareket.Where(x=>x.İşlemDurum==true).ToList();
            return View(değer);
        }
    }
}