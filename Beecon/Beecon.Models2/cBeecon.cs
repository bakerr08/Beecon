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
	public class cBeecon
	{
		#region Beecon Properties

		int beeconID;
		public int BeeconID
		{
			get { return beeconID; }
			set { beeconID = value; }
		}
		
		string beeconLongitude;
		public string BeeconLongitude
		{
			get { return beeconLongitude; }
			set { beeconLongitude = value; }
		}
		
		string beeconLatitude;
		public string BeeconLatitude
		{
			get { return beeconLatitude; }
			set { beeconLatitude = value; }
		}
		
		string beeconDescription;
		public string BeeconDescription
		{
			get { return beeconDescription; }
			set { beeconDescription = value; }
		}
		
		DateTime beeconDateCreated;
		public DateTime BeeconDateCreated
		{
			get { return beeconDateCreated; }
			set { beeconDateCreated = value; }
		}
		
		DateTime beeconDateExpired;
		public DateTime BeeconDateExpired
		{
			get { return beeconDateExpired; }
			set { beeconDateExpired = value; }
		}
		
		int userId;
		public int UserId
		{
			get { return userId; }
			set { userId = value; }
		}
		
		string beeconContentURL;
		public string BeeconContentURL
		{
			get { return beeconContentURL; }
			set { beeconContentURL = value; }
		}
		
		int beeconPrivacyTypeID;
		public int BeeconPrivacyTypeID
		{
			get { return beeconPrivacyTypeID; }
			set { beeconPrivacyTypeID = value; }
		}

		#endregion

		public cBeecon()
		{
		}

		public cBeecon(int _id, string _latitude, string _longitude, string _description, DateTime _datecreated, 
					   DateTime _dateexpired, int _userid, string _beeconcontentURL, int _beeconprivacytypeid)
		{
			BeeconID = _id;
			BeeconLatitude = _latitude;
			BeeconLongitude = _longitude;
			BeeconDescription = _description;
			BeeconDateCreated = _datecreated;
			BeeconDateExpired = _dateexpired;
			UserId = _userid;
			beeconContentURL = _beeconcontentURL;
			BeeconPrivacyTypeID = _beeconprivacytypeid;
		}
		//public void GetBeecon(int query_user_id, Action completion)
		public void GetBeecon(int query_user_id)
        {
            //_Completion = completion;
            Dictionary<string, string> d = new Dictionary<string, string>();
			d.Add("tagid", query_user_id.ToString());
            string post_json = Newtonsoft.Json.JsonConvert.SerializeObject(d);
            PostDataWithOperation("getbeecon", post_json);
          
        }

		public string ConvertToJson(cBeecon _beecon)
		{
			string json = JsonConvert.SerializeObject (_beecon);
			return json;

		}

		public cBeecon ConvertJsonToUser(string json)
		{
			var beecon = JsonConvert.DeserializeObject<cBeecon> (json);
			return beecon;
		}

		public void CreateBeecon(cBeecon _beecon)
		{
			cBeecon beecon = new cBeecon ();
			beecon = _beecon;

			//build JSON string
			//post to website


		}
        public string PostDataWithOperation(string operation, string JSON)
        {
            var httpReq = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}/{1}", getTargetUrl(), operation));

            httpReq.BeginGetResponse((ar) =>
            {

                var request = (HttpWebRequest)ar.AsyncState;
                //set http method
                request.Method = "POST";
                //content type
                request.ContentType = "text/html";
                byte[] buffer = Encoding.UTF8.GetBytes(JSON);
                using (var response = (HttpWebResponse)request.EndGetResponse(ar))
                {

                    //var s = response.GetResponseStream ();
                    Stream PostData = response.GetResponseStream();
                    StreamReader response_reader = new StreamReader(PostData);
                    string response_json = response_reader.ReadToEnd();
                    response_json = processResponse(response_json);
                    //RunOnUiThread (() => {
                    LoadJson(response_json);
                    
                }

            }, httpReq);

            return "Success";
        }
        public string processResponse(string response_json)
        {
            //puts the response into a dynamic object
            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(response_json);
            Dictionary<string, string> data = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(response_json);

            if (data["operation"] == "SignIn")//Name of the opperation 
            {
                //check for success
                if (data["message"] == "Success")
                {
                    FromData(data);//deserilize the JSON into a beecon
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
        public static cBeecon FromData(Dictionary<string, string> data)
        {
            cBeecon beecon = new cBeecon();
            beecon.beeconID = Convert.ToInt32(data["tagid"]);
            beecon.beeconLongitude = data["taglongitude”"];
            beecon.beeconLatitude = data["“taglatitude”"];
            beecon.beeconDescription = data["tagdescription"];
            beecon.beeconDateCreated = Convert.ToDateTime(data["tagdatecreated"]);
            beecon.beeconDateExpired = Convert.ToDateTime(data["tagexpired"]);
            beecon.userId = Convert.ToInt32(data["userid"]);
            beecon.beeconContentURL = data["tagcontent_url"];
            beecon.beeconPrivacyTypeID = Convert.ToInt32(data["privacytypeid"]);
            return beecon;
        }
        public string getTargetUrl()
        {
            string targetURL = "http://itweb.fvtc.edu/beecon/Beecon";
            return targetURL;
        }
        public void LoadJson(string json)
        {
            var beecon = JsonConvert.DeserializeObject<cBeecon>(json);
            beeconID = beecon.beeconID;
            beeconLongitude = beecon.beeconLongitude;
            beeconLatitude = beecon.beeconLatitude;
            beeconDescription = beecon.beeconDescription;
            beeconDateCreated = beecon.beeconDateCreated;
            beeconDateExpired = beecon.beeconDateExpired;
            userId = beecon.userId;
            beeconContentURL = beecon.beeconContentURL;
            beeconPrivacyTypeID = beecon.beeconPrivacyTypeID;
            

        }
	}
}

