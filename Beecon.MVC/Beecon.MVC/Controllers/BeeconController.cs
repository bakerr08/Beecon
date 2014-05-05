using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beecon.MVC.Models;

namespace Beecon.MVC.Controllers
{
    public class BeeconController : Controller
    {
        private BeeconDBEntitiesBOB db = new BeeconDBEntitiesBOB();

        //
        // GET: /Beecon/

        public ActionResult Index()
        {
            var tags = db.Tags.Include(t => t.TagPrivacyType).Include(t => t.User);
            return View(tags.ToList());
        }

        //
        // GET: /Beecon/Details/5

        public ActionResult Details(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // GET: /Beecon/Create

        public ActionResult Create()
        {
            ViewBag.PrivacyTypeID = new SelectList(db.TagPrivacyTypes, "PrivacyTypeID", "PrivacyDescription");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email");
            return View();
        }

        //
        // POST: /Beecon/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrivacyTypeID = new SelectList(db.TagPrivacyTypes, "PrivacyTypeID", "PrivacyDescription", tag.PrivacyTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", tag.UserID);
            return View(tag);
        }

        //
        // GET: /Beecon/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrivacyTypeID = new SelectList(db.TagPrivacyTypes, "PrivacyTypeID", "PrivacyDescription", tag.PrivacyTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", tag.UserID);
            return View(tag);
        }

        //
        // POST: /Beecon/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrivacyTypeID = new SelectList(db.TagPrivacyTypes, "PrivacyTypeID", "PrivacyDescription", tag.PrivacyTypeID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", tag.UserID);
            return View(tag);
        }

        //
        // GET: /Beecon/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }

        //
        // POST: /Beecon/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tag tag = db.Tags.Find(id);
            db.Tags.Remove(tag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GetAllBeecons()
        {

            var Tags = db.Tags.ToList();
            ViewData["Tags"] = Tags;
            return View();
        }

        public ActionResult GetBeecon(string json)
        {
            ViewBag.Operation = "GetBeecon";

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            int id = data.tagid;

            var Beecon = db.Tags.Find(id);


            ViewBag.Beecon = Beecon;

            if (Beecon != null)
            {
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Fail";
            }

            return View();
        }


        public ActionResult GetAllCategories()
        {

            var Categories = db.Categories.ToList();
            ViewData["Categories"] = Categories;
            return View();
        }

        public ActionResult CreateBeacon(string json)
        {

            ViewBag.Operation = "CreateBeecon";


            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            Tag tag = new Tag();

            tag.TagLongitude = data.TagLongitude;
            tag.TagLatitude = data.TagLatitude;
            tag.TagDescription = data.TagDescription;
            tag.TagDateCreated = DateTime.Now;
            tag.TagExpired = data.TagExpired;
            tag.UserID = data.UserID;
            tag.TagContent_URL = data.TagContent_URL;
            tag.TagPrivacyType = data.PrivacyTypeID;

            db.Tags.Add(tag);
            db.SaveChanges();



            ViewBag.Beecon = tag;

            if (ViewBag.Beecon != null)
            {
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Fail";
            }

            //ViewData["TagLongitude"] = data.TagLongitude;
            //ViewData["TagLatitude"] = data.TagLatitude;
            //ViewData["TagDescription"] = data.TagDescription;
            //ViewData["DateCreated"] = DateTime.Now;
            //ViewData["TagExpired"] = data.TagExpired;
            //ViewData["UserID"] = data.UserID;
            //ViewData["TagContent_URL"] = data.TagContent_URL;
            //ViewData["PrivacyTypeID"] = data.PrivacyTypeID;


            return View();

        }

        public ActionResult GetBeeconByFilter(string json)
        {

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //var CategoryToFilter = data.category;

            //var CategorySearch = db.Categories.SingleOrDefault(c => c.Category1 == CategoryToFilter);


            //var CategoryID = CategorySearch.CategoryID;

            //var Tags = db.Tags.ToList();

            ////var categoriesList = db.Categories.ToList();


            //List<Tag> TagWithFilter = new List<Tag>();

            //foreach (Tag t in Tags)
            //{

            //    if (t.TagID == CategoryID)
            //    {

            //        TagWithFilter.Add(t);
            //    }
                

            //}

            //ViewBag.Beecons = TagWithFilter;

            //if (TagWithFilter != null)
            //{
            //    ViewBag.Message = "Success";
            //}
            //else
            //{
            //    ViewBag.Message = "Fail";
            //}


            return View();
        }

        public ActionResult GetBeeconByProximity(string json)
        {

            ViewBag.Operation = "GetBeeconByProximity";

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            double prox = double.Parse(data.proximity);
            var CurrentLatitude = double.Parse(data.currentlatitude);
            var CurrentLongitude = double.Parse(data.currentlongitude);


            var Tags = db.Tags.ToList();

            List<Tag> TagWithProx = new List<Tag>();

            foreach (Tag t in Tags)
            {
                double CalcProx = CalculateGreatCircleDistance(double.Parse(t.TagLatitude), double.Parse(t.TagLongitude), CurrentLatitude, CurrentLongitude, prox);


                if (CalcProx == 20)
                {
                    TagWithProx.Add(t);
                }

            }

            ViewBag.Beecons = TagWithProx;

            if (TagWithProx != null)
            {
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Fail";
            }

            return View();
        }


        double CalculateGreatCircleDistance(double lat1, double long1, double lat2, double long2, double radius)
        {


            // if your lat and long are in degrees then divide by 180/PI to convert to radians.
            
            return radius * Math.Acos(
                Math.Sin(lat1) * Math.Sin(lat2)
                + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(long2 - long1));
        }


    }
}