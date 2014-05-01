using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
			processResponse(response_json);
			return response_json;

		}

		private void processResponse(string response_json)
		{

			try
			{
				dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response_json);

				if (data.operation == "SignIn")
				{
					user = UserProfile.FromData(data.user);
					if (user != null)
					{
						byte[] buffer = user.ProfileImage; 
						MemoryStream ms = new MemoryStream(buffer);
						picProfileImage.Image = Image.FromStream(ms);

						txtUpdateUser_Bio.Text = user.Bio;
						txtUpdateUser_Name.Text = user.Name;
						txtUpdateUser_Zip.Text = user.Zip;
						if (user.Sex == Sex.Male)
						{
							rbUpdateUser_Male.Checked = true;
							rbUpdateUser_Female.Checked = false;
						}
						else
						{
							rbUpdateUser_Male.Checked = false;
							rbUpdateUser_Female.Checked = true;
						}

						DateTime birthdate =(DateTime) user.Birthdate;  //FromUnixTime((string) user.birthdate);
						dateUpdateUser_Birthdate.Value = birthdate;
						string location = user.Location;
						if (location != "")
						{
							string[] splitString = { "," };
							double latitude = Convert.ToDouble(location.Split(splitString, StringSplitOptions.None)[0]);
							double longitude = Convert.ToDouble(location.Split(splitString, StringSplitOptions.None)[1]);
							txtUpdateUser_Latitude.Text = latitude.ToString();
							txtUpdateUser_Longitude.Text = longitude.ToString();
						}
					}

				}
				else if (data.operation == "allgames")
				{
					List<Game> games = new List<Game>();
					foreach (dynamic g in data.games)
					{
						Game game = Game.FromData(g);
						games.Add(game);
					}
				}


		private string getTargetUrl()
		{
			string targetURL = "http://itweb.fvtc.edu/beecon/User";
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

