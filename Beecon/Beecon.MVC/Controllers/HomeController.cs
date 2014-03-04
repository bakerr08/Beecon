using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Newtonsoft.Json;
using Beecon.Models;

namespace Beecon.MVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index ()
		{


			var user = new cUser { Id = new Guid("0a51414a-3d42-4604-8edb-b645dbaaf761"), FirstName = "Bob", LastName = "Baker", Zip = "54915", Dob = new DateTime(1980, 6, 1), Password = "password", BeeconsFound = 100, BeeconsCreated = 2, Gender = "Male", Address = "555 N Five Rd", City = "Appleton", State = "WI", Email = "BobBaker@Gmail.com"};

			var json = JsonConvert.SerializeObject (user);

			ViewData ["JsonSerialized"] = json;

			var user2 = JsonConvert.DeserializeObject<cUser> (json);

			// the user's info
			ViewData ["UserId"] = user2.Id;
			ViewData ["FirstName"] = user2.FirstName;
			ViewData ["LastName"] = user2.LastName;
			ViewData ["Email"] = user2.Email;
			ViewData ["Address"] = user2.Address;
			ViewData ["City"] = user2.City;
			ViewData ["State"] = user2.State;
			ViewData ["Zip"] = user2.Zip;
			ViewData ["Dob"] = user2.Dob;
			ViewData ["Password"] = user2.Password;
			ViewData ["BeeconsFound"] = user2.BeeconsFound;
			ViewData ["BeeconsCreated"] = user2.BeeconsCreated;
			ViewData ["Gender"] = user2.Gender;


			return View ();
		}
	}
}

