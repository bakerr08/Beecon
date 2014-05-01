using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Beecon
{
	[Activity (Label = "Beecon", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button CreateBeecon = FindViewById<Button> (Resource.Id.btnCreateBeecon);
			Button ViewMap = FindViewById<Button> (Resource.Id.btnViewMap);

			CreateBeecon.Click += delegate {
				// Switch to view to gather beecon deatails
				StartActivity (typeof(CreateActivity));
			};

			ViewMap.Click += delegate {
				// Switch to view to Map
				StartActivity (typeof(HomeActivity));
			};
		}
	}
}


