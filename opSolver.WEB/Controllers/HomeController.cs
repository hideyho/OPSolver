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

        //Simplex General
        SData item = new SData()
        {
            dtVariables =
                {

                    new List<double>(){120,90,80,70},
                    new List<double>(){1,1,1,1}
                },
            dtSign =
                {
                    "<=",
                    ">="
                },
            dtB =
                {
                    2800000,
                    30000
                },
            dtFunctionVariables =
                {
                    105-83, 105-89, 105-95, 105-98
                },
            isMax = true
        };
        //Genetic general
        GData gitem = new GData()
        {
            population = 100,
            iterations = 50,
            kf = new List<List<double>>()
            {
                new List<double>(){105-83,105-89,105-95, 105-98},
                 new List<double>(){1,1,1,1,30000},
                new List<double>(){120,90,80,70,2800000}

            }
        };

        //Culture

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> cultures = new List<string>() { "ru", "en" };
            if (!cultures.Contains(lang))
                lang = "en";
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
        [HttpPost]
        public ActionResult SimplexGeneral(SData item)
        {
            item = this.item;
            item.Solve();
            return View("Simplex", item);
        }
        [HttpPost]
        public ActionResult Simplex1(SData item)
        {
            item = this.item;
            item.dtFunctionVariables = new List<double>
            {
                105-83-83*0.05, 105-89-89*0.05, 105-95-95-0.05, 105-98-98*0.05
            };
          
            item.Solve();
            return View("Simplex", item);
        }
        [HttpPost]
        public ActionResult Simplex2(SData item)
        {
            item = this.item;
            item.dtVariables = new List<List<double>>
            {
                new List<double>(){120-120*0.05,90-90*0.05,80-80*0.05,70-70*0.05},
                new List<double>(){1,1,1,1}
            };
           
            item.Solve();
            return View("Simplex", item);
        }
        public ActionResult Simplex3(SData item)
        {
            item = this.item;
            item.dtFunctionVariables = new List<double>
            {
                100-83, 100-89, 100-95, 100-98
            };
            item.Solve();
            return View("Simplex", item);
        }

        //Genetic
        public ActionResult Genetic()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Genetic(GData item)
        {
            item.Solve();
            return View(item);
        }
        [HttpPost]
        public ActionResult GeneticGeneral(GData item)
        {
            item = gitem;
            item.Solve();
            return View("Genetic",item);
        }
        public ActionResult Genetic1(GData item)
        {
            item = gitem;
            item.kf[0] = new List<double>() { 105 - 83 - 83 * 0.05, 105 - 89 - 89 * 0.05, 105 - 95 -95- 0.05, 105 - 98 - 98 * 0.05 };
            item.Solve();
            return View("Genetic", item);
        }
        public ActionResult Genetic2(GData item)
        {
            item = gitem;
            item.kf[2] = new List<double>() { 120 - 120 * 0.05, 90 - 90 * 0.05, 80 - 80 * 0.05, 70 - 70 * 0.05, 2800000 };
            item.Solve();
            return View("Genetic", item);
        }
        public ActionResult Genetic3(GData item)
        {
            item = gitem;
            item.kf[0] = new List<double>() { 100 - 83, 100 - 89, 100 - 95, 100 - 98 };
            item.Solve();
            return View("Genetic", item);
        }

        //About
        public ActionResult About()
        {
            return View();
        }

    }
}