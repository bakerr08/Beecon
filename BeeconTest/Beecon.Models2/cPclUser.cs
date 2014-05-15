using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections;
using System.Dynamic;
using System.ComponentModel;

namespace Beecon.Models2
{
	public class cPclUser:cUser
	{
		public cPclUser ()
		{
		}
		public void PostDataWithOperation(string operation, string JSON)
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

			//return "true";
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
		public string getTargetUrl()
		{
			string targetURL = "http://itweb.fvtc.edu/beecon/User";
			return targetURL;
		}
		public void LoadJson(string json)
		{
			var user = JsonConvert.DeserializeObject<cUser> (json);
			Id = user.Id;
			LastName = user.LastName;
			FirstName = user.FirstName;
			Email = user.email;
			Gender = user.gender;
			Address = user.address;
			Zip = user.zip;
			Dob = user.dob;
			Password = user.password;
			BeeconsCreated = user.beeconsCreated;
			BeeconsFound = user.beeconsFound;

		}
	}
}

