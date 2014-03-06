using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Beecon.MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }


        #region JSON Operators

        public ActionResult AllUsers()
        {
            return View();
        }

        public ActionResult AllBeecon()
        {
            return View();
        }

        public ActionResult BeeconUser()
        {
            return View();
        }

        public ActionResult Beecon()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult CreateBeecon()
        {
            return View();
        }

        public ActionResult DeleteUser()
        {
            return View();
        }

        public ActionResult DeleteBeecon()
        {
            return View();
        } 

        #endregion

    }
}
