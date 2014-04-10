using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Beecon.Models
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

