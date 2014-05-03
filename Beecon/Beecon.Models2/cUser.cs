using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

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
			//build request
			System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(string.Format("{0}/{1}", getTargetUrl(), operation));
			//set http method
			request.Method = "POST";
			//content type
			request.ContentType = "text/html";
			//build json
			//encode json
			byte[] buffer = Encoding.UTF8.GetBytes(JSON);
			//write to request body
			Stream PostData = request.GetRequestStream();
			PostData.Write(buffer, 0, buffer.Length);
			PostData.Close();
			//get response
			Stream response = request.GetResponse().GetResponseStream();
			//read response body
			StreamReader response_reader = new StreamReader(response);
			string response_json = response_reader.ReadToEnd();
			response_json = processResponse(response_json);
			return response_json;
		}

		public string processResponse(string response_json)
		{
			//puts the response into a dynamic object
			dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response_json);

			if (data.operation == "SignIn")//Name of the opperation 
			{
				//check for success
				if(data.message == "Success")
				{
					this.FromData(data.user);//deserilize the JSON into a user
					return data.message; //return the Success to the form
				}
				else
				{
					return false;
				}

			}
			else if (data.operation == "allgames")
			{
				return false;
			}
		}

		public static cUser FromData(dynamic data)
		{
			cUser user = new cUser();
			user.Id = data.user_id;
			user.Email = data.email;
			user.FirstName = data.firstname;
			user.LastName = data.lastname;
			user.Zip = data.zip;
			user.Dob = data.dob;
			user.Gender = data.gender;
			user.Address = data.address;
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

		public cUser ConvertJsonToUser(string json)
		{
			var user = JsonConvert.DeserializeObject<cUser> (json);
			return user;
		}
	}
}

