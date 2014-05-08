using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Geolocation;

namespace Beecon
{
	[Activity (Label = "BeeconTextActivity")]			
	public class BeeconTextActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.BeeconText);
			Button Submit = FindViewById<Button> (Resource.Id.btnSubmitBeecon);
			String BeeconTxt = (Resource.Id.txtBeeconText);

			string Time;
			string Latitude;
			string Longitude;
			string Proximity;
			Geolocator geolocator;

			var locator = new Geolocator (this) {DesiredAccuracy=50};
			this.geolocator.GetPositionAsync (timeout:10000) .CountinueWith (t => {

				Time.text = t.Result.Timestamp.ToString("G");
				Proximity.text = t.Result.Accuracy;
				Latitude.text = t.Result.Latitude.ToString("N4");
				Longitude.text = t.Result.Longitude.ToString("N4");

			}, TaskScheduler.FromCurrentSynchronizationContext());



			btnSubmitBeecon.Click += (sender, e) =>  {
			if (BeeconTxt == String.Empty)
				return;

				// Take Beecon Text Send Serialize it to JSON and Send it


			}


		}
	}
}

