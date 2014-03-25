using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Beecon.Models
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

		public string ConvertToJson(cBeecon _beecon)
		{
			var json = JsonConvert.SerializeObject (beecon);
			return json;

		}

		public cBeecon ConvertJsonToUser(string json)
		{
			var beecon = JsonConvert.DeserializeObject<cUser> (json);
			return beecon;
		}



	}
}

