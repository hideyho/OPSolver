using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using opSolver.WEB.Utils;
using opSolver.OPS.Methods.Simplex;


namespace opSolver.WEB.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        IUntiOfWork db;
        public HomeController(IUntiOfWork uof)
        {
            db = uof;
        }

        //Culture
       
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(lang))
                lang = "ru";
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;
            else
            {
                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        //Index
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User item)
        {
            
            if (ModelState.IsValid)
            {

                db.Users.Create(item);
                db.Save();

                Response.SetCookie(new HttpCookie("userName") {Value = item.Name });
                Response.SetCookie(new HttpCookie("userID") { Value = Convert.ToString(item.Id)});
            }
            return View();
                
        }
        //Simplex
        public ActionResult Simplex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Simplex(SData item, string Method)
        {
            try
            {
                item.Solve();
            }
            catch (Exception) { }
            
            return View(item);
        }

    }
}