using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Beecon.Models2;
using Newtonsoft.Json;
namespace Beecon
{
	[Activity (Label = "Beecon")]
	public class MainActivity : Activity
	{
		cUser oUser = new cUser();
		string beeconGps = "geo:";
		cBeecon oBeecon = new cBeecon ();
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button CreateBeecon = FindViewById<Button> (Resource.Id.btnCreateBeecon);
			Button ViewMap = FindViewById<Button> (Resource.Id.btnViewMap);

			var user = JsonConvert.DeserializeObject<cUser> (Intent.GetStringExtra ("User"));
			//oBeecon.GetBeecon (20);
			//CreateBeecon.Click += delegate {
				// Switch to view to gather beecon deatails
			//	StartActivity (typeof(CreateActivity));
			//};

			ViewMap.Click += delegate {
				// Switch to view to Map
				var geoUri = Android.Net.Uri.Parse ("geo:42.374260,-71.120824,3.0");
				var mapIntent = new Intent (Intent.ActionView, geoUri);
				StartActivity (mapIntent);
				//StartActivity (typeof(HomeActivity));
			};
		}

	}
}


