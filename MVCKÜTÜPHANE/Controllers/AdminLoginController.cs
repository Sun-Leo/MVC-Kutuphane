using MVCKÜTÜPHANE.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using System.Web.Security;

namespace MVCKÜTÜPHANE.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DBKütüphaneEntities db = new DBKütüphaneEntities();

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Admin a)
        {
            var login = db.Tbl_Admin.FirstOrDefault(x => x.AdminMail == a.AdminMail && x.AdminŞifre == a.AdminŞifre);
            if(login != null) 
            {
                FormsAuthentication.SetAuthCookie(login.AdminMail, false);
                Session["AdminMail"] = login.AdminMail.ToString();
                return RedirectToAction("Index", "AdminMainPage");

            }
            else
            {
                return View();
            }
           
        }
    }
}