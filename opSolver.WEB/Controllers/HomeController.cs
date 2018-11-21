using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using opSolver.WEB.Utils;
using opSolver.OPS.Methods.Simplex;
using opSolver.OPS.Methods.Genetic;

namespace opSolver.WEB.Controllers
{
    [Authorize]
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
        public ActionResult Index(ApplicationUser item)
        {
            
            if (ModelState.IsValid)
            {

                //db.Users.Create(item);
                db.Save();

                //Response.SetCookie(new HttpCookie("userName") {Value = item.Name });
                //Response.SetCookie(new HttpCookie("userID") { Value = Convert.ToString(item.Id)});
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

        //Genetic
        public ActionResult Genetic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Genetic(GData item)
        {
            item = new GData
            {
                population = 50,
                isMax = true,
                minValue = 0,
                maxValue = 30000,
                function = "(105-83)*x1+(105-89)*x2+(105-95)*x3+(105-98)*x4",
                limit1 = new OPS.Methods.Genetic.Model.Limit
                {
                    function = "x1+x2+x3+x4",
                    sign = ">=",
                    limitResult = 30000
                },
                limit2 = new OPS.Methods.Genetic.Model.Limit
                {
                    function = "120*x1+90*x2+80*x3+70*x4",
                    sign = "<=",
                    limitResult = 2800000
                },
                iterations = 10
            };
            item.Solve();
            return View(item);
        }
        
        //About
        public ActionResult About()
        {
            return View();
        }

    }
}