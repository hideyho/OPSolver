using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using opSolver.DAL.Entities;
using opSolver.DAL.Interfaces;
using opSolver.WEB.Utils;


namespace opSolver.WEB.Controllers
{
    public class HomeController : Controller
    {
        IUntiOfWork db;
        public HomeController(IUntiOfWork uof)
        {
            db = uof;
        }
       

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

                var cookie = new HttpCookie("userName")
                {
                    Value = item.Name
                };
                Response.SetCookie(cookie);

            }
            return View();
                
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}