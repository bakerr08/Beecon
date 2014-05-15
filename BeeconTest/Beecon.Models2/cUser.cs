using System;
using System.Collections.Generic;
using System.Text;
//using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections;
using System.Dynamic;
using System.ComponentModel;

namespace Beecon.Models2
{
	public class cUser
	{
		#region Properties

		int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		string email;
		public string Email
		{
			get { return email; }
			set { email = value; }
		}

		string firstName;
		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}

		string lastName;
		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}

		string zip;
		public string Zip
		{
			get { return zip; }
			set { zip = value; }
		}

		DateTime? dob;
		public DateTime? Dob
		{
			get { return dob; }
			set { dob = value; }
		}

		string password;
		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		int? beeconsFound;
		public int? BeeconsFound
		{
			get { return beeconsFound; }
			set { beeconsFound = value; }
		}

		int? beeconsCreated;
		public int? BeeconsCreated
		{
			get { return beeconsCreated; }
			set { beeconsCreated = value; }
		}

		string gender;
		public string Gender
		{
			get { return gender; }
			set { gender = value; }
		}

		string address;
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
			
		#endregion

		public string Request;
		public string Response;
		public string Status;
		public int Number;
		public string Message;
		//private int _GameID;
		private System.Net.HttpWebRequest _request;
		Action _Completion;
		public cUser()
		{

		}

		public cUser(int _id, string _lastName, string _firstName, string _email, string _gender, string _address, string _zip, DateTime? _dob, string _password, int? _beeconsCreated, int? _beeconsFound)
		{
			id = _id;
			lastName = _lastName;
			firstName = _firstName;
			email = _email;
			gender = _gender;
			address = _address;
			zip = _zip;
			dob = _dob;
			password = _password;
			beeconsCreated = _beeconsCreated;
			beeconsFound = _beeconsFound;
		}

		public string PostDataWithOperation(string operation, string JSON)
		{
			var httpReq = (HttpWebRequest)HttpWebRequest.Create (string.Format("{0}/{1}", getTargetUrl(), operation));

			httpReq.BeginGetResponse ((ar) => {

				var request = (HttpWebRequest)ar.AsyncState;
				//set http method
				request.Method = "POST";
				//content type
				request.ContentType = "text/html";
				byte[] buffer = Encoding.UTF8.GetBytes(JSON);
				using (var response = (HttpWebResponse)request.EndGetResponse (ar)) {

					//var s = response.GetResponseStream ();
					Stream PostData = response.GetResponseStream ();
					StreamReader response_reader = new StreamReader(PostData);
					string response_json = response_reader.ReadToEnd();
					response_json = processResponse(response_json);
					//RunOnUiThread (() => {
					LoadJson(response_json);
					//	});
					//return response_json;

					//get response
					//Stream response = request.GetResponse().GetResponseStream();
					//read response body
					//StreamReader response_reader = new StreamReader(response);
					//string response_json = response_reader.ReadToEnd();
					//response_json = processResponse(response_json);
					//return response_json;
					//	return "true";
					//	var j = (JsonObject)JsonObject.Load (s);

					//	var results = (from result in (JsonArray)j ["results"]
					//		let jResult = result as JsonObject
					//		select jResult ["text"].ToString ()).ToArray ();

					//	RunOnUiThread (() => {
					//	ListAdapter = new ArrayAdapter<string> (this, Resource.Layout.TweetItemView, results);
					//	});
				}            

			}, httpReq);

			return "Success";
		}


		public string processResponse(string response_json)
		{
			//puts the response into a dynamic object
			//dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response_json);
			Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string,string>>(response_json);

			if (data["operation"] == "SignIn")//Name of the opperation 
			{
				//check for success
				if(data["message"] == "Success")
				{
					FromData(data);//deserilize the JSON into a user
					return data["message"]; //return the Success to the form
				}
				else
				{
					return data["message"]; //return the Fail to the form
				}
			}
			else if (data["operation"] == "allgames")
			{
				return data["message"];
			}

			return "true";
		}

		public static cUser FromData(Dictionary<string, string> data)
		{
			cUser user = new cUser();
			user.Id = Convert.ToInt32(data["user_id"]);
			user.Email = data["email"];
			user.FirstName = data["firstname"];
			user.LastName = data["lastname"];
			user.Zip = data["zip"];
			user.Dob = Convert.ToDateTime(data["dob"]);
			user.Gender = data["gender"];
			user.Address = data["address"];
			return user;
		}

		public string getTargetUrl()
		{
			string targetURL = "http://itweb.fvtc.edu/beecon/User";
			return targetURL;
		}
		public string ConvertToJson(cUser _user)
		{
			var json = JsonConvert.SerializeObject (_user);
			return json;

		}
		public void LoadJson(string json)
		{
			var user = JsonConvert.DeserializeObject<cUser> (json);
			id = user.id;
			lastName = user.lastName;
			firstName = user.firstName;
			email = user.email;
			gender = user.gender;
			address = user.address;
			zip = user.zip;
			dob = user.dob;
			password = user.password;
			beeconsCreated = user.beeconsCreated;
			beeconsFound = user.beeconsFound;

		}

		public cUser ConvertJsonToUser(string json)
		{
			var user = JsonConvert.DeserializeObject<cUser> (json);
			return user;
		}
		private void EndResponse(IAsyncResult result)
		{
			//_request.EndGetResponse(result);
			Stream response = (result.AsyncState as System.Net.HttpWebRequest).EndGetResponse(result).GetResponseStream();
			StreamReader response_reader = new StreamReader(response);
			string response_json = response_reader.ReadToEnd();
			processResponse(response_json);
			_Completion();
		}
		public void Authenticate(string username, string password, Action completion)
		{
			_Completion = completion;
			//string hash = createAuthHash(password);
			//string post_json = "{\"username\":\"" + username + "\", \"hash\":\"" + hash + "\"}";
			//PostDataWithOperation("auth", post_json);

		}
		public void Register(string username, string password, string email, Action completion)
		{
			_Completion = completion;
			Dictionary<string, string> d = new Dictionary<string, string>();
			d.Add("username", username);
			d.Add("password", password);
			d.Add("email", email);
			string post_json = Newtonsoft.Json.JsonConvert.SerializeObject(d);
			PostDataWithOperation("createuser", post_json);

		}
	}
}

