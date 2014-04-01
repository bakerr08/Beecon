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

namespace Beecon
{
	[Activity (Label = "StartActivity")]			
	public class StartActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Start);

			Button SignIn = FindViewById<Button> (Resource.Id.SignIn);
			Button SignUp = FindViewById<Button> (Resource.Id.SignUp);
			String Email = FindViewById<String> (Resource.Id.Email);
			String Password = FindViewById<String> (Resource.Id.Password);

			SignIn.Click += delegate {
			


			};

			SignUp.Click += delegate {
			


			};
		}
	}
}

