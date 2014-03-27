using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Beecon.MVC.Models;

namespace Beecon.MVC.Controllers
{
    public class HomeController : Controller
    {

        BeeconDBEntities db = new BeeconDBEntities();



        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Beecon";
            var gameID = 1;
            ViewBag.gameID = gameID;


            DbSet<User> users = db.Users;
            ViewData["users"] = users;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
