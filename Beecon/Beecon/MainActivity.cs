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

			Button btnCreateBeecon = FindViewById<Button> (Resource.Id.btnCreateBeecon);

			btnCreateBeecon.Click += delegate {
				//switch to view to gather beecon deatails
				StartActivity (typeof(CreateActivity));
			};
		}
	}
}


