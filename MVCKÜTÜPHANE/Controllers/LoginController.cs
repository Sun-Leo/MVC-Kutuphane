using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCKÜTÜPHANE.Models;
using MVCKÜTÜPHANE.Models.Entity;
using System.Security;
using System.Web.Security;

namespace MVCKÜTÜPHANE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBKütüphaneEntities db= new DBKütüphaneEntities();
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Tbl_Üye üy)
        {
            var login = db.Tbl_Üye.FirstOrDefault(x => x.MAİL == üy.MAİL && x.ŞİFRE==üy.ŞİFRE);
            if(login != null)
            {
                FormsAuthentication.SetAuthCookie(login.MAİL, false);
                Session["Mail"] = login.MAİL.ToString();
                return RedirectToAction("Index","MemberPanel");
            }
            else
            {
                return View();
            }
           
        }
    }
}