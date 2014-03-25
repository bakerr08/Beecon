using Beecon.Models;
using Beecon.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beecon.MVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index(int id)
        {



            return View();
        }

        public ActionResult AllUsers()
        {


            try
            {
                // Create a data context
                DataAccessDataContext oDc = new DataAccessDataContext();

                var otblUsers = from c in oDc.tblUsers
                                select c;


                var oUsers = new List<cUser>();

                foreach (tblUser User in otblUsers)
                {
                    cUser oUser = new cUser { Id = User.UserID, FirstName = User.FirstName, LastName = User.LastName, Zip = User.ZipCode, Dob = User.Dob, Password = User.PasswordHashed, BeeconsFound = User.BeeconsFound, BeeconsCreated = User.BeeconsPosted, Gender = User.Gender, Address = User.Address, City = User.City, State = User.State, Email = User.Email };

                    //cUser oUser = new cUser(User.UserID, User.LastName, User.FirstName, User.Email, User.Gender, User.Address, User.City, User.State, User.ZipCode, User.Dob, User.PasswordHashed, User.BeeconsPosted, User.BeeconsFound);

                    oUsers.Add(oUser);
                    //ViewData["allUsers"] = oUsers;
                    var json = JsonConvert.SerializeObject(oUser);


                    //var user = new cUser { Id = new Guid("0a51414a-3d42-4604-8edb-b645dbaaf761"), FirstName = "Bob", LastName = "Baker", Zip = "54915", Dob = new DateTime(1980, 6, 1), Password = "password", BeeconsFound = 100, BeeconsCreated = 2, Gender = "Male", Address = "555 N Five Rd", City = "Appleton", State = "WI", Email = "BobBaker@Gmail.com" };

                    ViewData["JsonSerialized"] = json;

                    var user2 = JsonConvert.DeserializeObject<cUser>(json);

                    ViewData["UserId"] = user2.Id;

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View();




        }

        

        public ActionResult BeeconUser()
        {


            try
            {
                // Create a data context
                DataAccessDataContext oDc = new DataAccessDataContext();

                var otblUsers = from c in oDc.tblUsers
                                where c.UserID == new Guid("6FAFBA5B-487C-40F6-A57C-EFAB40FD5EDE")
                                select c;


                var oUsers = new List<cUser>();

                foreach (tblUser User in otblUsers)
                {
                    cUser oUser = new cUser { Id = User.UserID, FirstName = User.FirstName, LastName = User.LastName, Zip = User.ZipCode, Dob = User.Dob, Password = User.PasswordHashed, BeeconsFound = User.BeeconsFound, BeeconsCreated = User.BeeconsPosted, Gender = User.Gender, Address = User.Address, City = User.City, State = User.State, Email = User.Email };

                    //cUser oUser = new cUser(User.UserID, User.LastName, User.FirstName, User.Email, User.Gender, User.Address, User.City, User.State, User.ZipCode, User.Dob, User.PasswordHashed, User.BeeconsPosted, User.BeeconsFound);

                    // oUsers.Add(oUser);
                    var json = JsonConvert.SerializeObject(oUser);


                    //var user = new cUser { Id = new Guid("0a51414a-3d42-4604-8edb-b645dbaaf761"), FirstName = "Bob", LastName = "Baker", Zip = "54915", Dob = new DateTime(1980, 6, 1), Password = "password", BeeconsFound = 100, BeeconsCreated = 2, Gender = "Male", Address = "555 N Five Rd", City = "Appleton", State = "WI", Email = "BobBaker@Gmail.com" };



                    ViewData["JsonSerialized"] = json;

                    var user2 = JsonConvert.DeserializeObject<cUser>(json);

                    ViewData["UserId"] = user2.Id;
                    ViewData["FirstName"] = user2.FirstName;
                    ViewData["LastName"] = user2.LastName;
                    ViewData["Email"] = user2.Email;
                    ViewData["Address"] = user2.Address;
                    ViewData["City"] = user2.City;
                    ViewData["State"] = user2.State;
                    ViewData["Zip"] = user2.Zip;
                    ViewData["Dob"] = user2.Dob;
                    ViewData["Password"] = user2.Password;
                    ViewData["BeeconsFound"] = user2.BeeconsFound;
                    ViewData["BeeconsCreated"] = user2.BeeconsCreated;
                    ViewData["Gender"] = user2.Gender;


                }


            }
            catch (Exception ex)
            {

                throw ex;
            }




            return View();
        }



        //public ActionResult CreateUser()
        //{
        //    return View();
        //}

       

        //public ActionResult DeleteUser()
        //{
        //    return View();
        //}

       


    }
}
