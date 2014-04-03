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
			var SignUp = FindViewById<Button> (Resource.Id.SignUp);
			String Email = (Resource.Id.Email.ToString());
			String Password = (Resource.Id.Password.ToString());

			SignIn.Click += delegate {
				//Error Handling
				if (Email == String.Empty){
					//Display Message*****

					Password = "";
					return;
				};
				if (Password == String.Empty) {
					//Display Message*****

					Password = "";
					return;
				};
				//Sign In Code


			};
			SignUp.Click += (sender, e) =>  {
				StartActivity (typeof(StartActivity));
			};
		}
	}
}

