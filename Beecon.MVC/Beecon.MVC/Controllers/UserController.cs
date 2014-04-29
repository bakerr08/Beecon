using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beecon.MVC.Models;
using Newtonsoft.Json;

namespace Beecon.MVC.Controllers
{
    public class UserController : Controller
    {
        private BeeconDBEntitiesBOB db = new BeeconDBEntitiesBOB();

        //
        // GET: /User/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }


        //
        // GET: /User/Details/5

        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GetAllUsers()
        {

            var users = db.Users.ToList();
            ViewData["users"] = users;
            return View();
        }

        public ActionResult GetUser(string json)
        {
            


           
           //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
           //int _userid = data.UserID;
            

            

           // var BeeconUser = db.Users.First(u => u.UserID == _userid);

           // ViewData["BeeconUser"] = BeeconUser;
            return View();
        }

        public ActionResult CreateUser(string json)
        {
            try
            {
                ViewBag.status = "ok";
                ViewBag.operation = "createuser";
                ViewBag.message = "Operation Successful";


                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

                User user = new User();

                user.Dob = data.Dob;
                user.Email = data.Email;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
                user.ZipCode = data.ZipCode;
                user.PasswordHashed = data.PasswprdHashed;
                user.TagsFound = 0;
                user.TagsPosted = 0;
                user.Gender = data.Gender;

                db.Users.Add(user);
                db.SaveChanges();

                ViewData["Dob"] = data.Dob;
                ViewData["Email"] = data.Email;
                ViewData["FirstName"] = data.FirstName;
                ViewData["LastName"] = data.LastName;
                ViewData["ZipCode"] = data.ZipCode;
                ViewData["PasswprdHashed"] = data.PasswprdHashed;
                ViewData["TagsFound"] = user.TagsFound;
                ViewData["TagsPosted"] = user.TagsPosted;
                ViewData["Gender"] = user.Gender;


                return View();
            }
            catch (Exception ex)
            {

                ViewBag.status = "denied";
                ViewBag.operation = "createuser";
                ViewBag.message = ex;
                return View();
            }
            
        }

        public ActionResult UpdateUser(string json)
        {

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            User user = new User();


            user.Dob = data.Dob;
            user.Email = data.Email;
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.ZipCode = data.ZipCode;
            user.PasswordHashed = data.PasswprdHashed;
            user.TagsFound = data.TagsFound;
            user.TagsPosted = data.TagsPosted;
            user.Gender = data.Gender;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();



            return View();
        }

        public ActionResult AddFriend(string json)
        {

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            FriendList friendlist = new FriendList();

            friendlist.Created = data.Created;
            friendlist.UserID = data.UserID;
            friendlist.UserIDRequested = data.UserIDRequested;

            db.FriendLists.Add(friendlist);
            db.SaveChanges();

            return View();
        }

        public ActionResult RemoveFriend(string json)
        {

            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            return View();
        }

        public ActionResult ViewFriendList(string json)
        {

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            //var userid = data.UserID;

            //var friendlist = db.FriendLists.Where(f => f.UserID == userid)
                                           //.Select(f => f.UserID).ToList();

            return View();
        }

        public ActionResult SignIn(string json)
        {
            if (json == null)
            {


                json = "{  \"email\": \"owuvoc96@ciqbkr.org\", \"password\": \"SL5UUBA0NHSJRJISVVE67K5A9URAQ34\"  } ";
            }
            
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            string _email = data.email;
            string _password = data.password;

            var BeeconUser = db.Users.SingleOrDefault(u => u.Email == _email);

            if (BeeconUser.Email != _email)
            {
                if (BeeconUser.PasswordHashed == _password)
                {
                    ViewBag.Message = "Success";
                    ViewData["BeeconUser"] = BeeconUser;

                }
                else
                {
                    ViewBag.Message = "Passwords don't match";
                }
            }
            else
            {
                ViewBag.Message = "Email not found";
            }

            //ViewData["BeeconUser"] = BeeconUser;
            return View();
        }
    }
}