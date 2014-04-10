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

        public ActionResult GetBeecon()
        {

            var Beecons = db.Tags.ToList();

            var Beecon = Beecons[1];

            ViewData["Beecon"] = Beecon;
            return View();
        }


        public ActionResult GetAllCategories()
        {

            var Categories = db.Categories.ToList();
            ViewData["Categories"] = Categories;
            return View();
        }

    }
}