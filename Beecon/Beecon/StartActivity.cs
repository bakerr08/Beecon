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
			String TextError = (Resource.Id.InputError);

			SignIn.Click += delegate {
				//Error Handling
				/*private void ErrorsBox(Object, EventArgs e)
				{
					AlertDialog.Builder ErrorMessage;
					ErrorMessage = new AlertDialog.Builder(this);
					ErrorMessage.SetTitle("Error");
					ErrorMessage.SetMessage("The email or passowrd you entered is incorrect. Please try again");
					ErrorMessage.SetCancelable(false);
					ErrorMessage.SetPositiveButton("OK", delegate { Finish();});
					ErrorMessage.Show();
				}*/
				if (Email == String.Empty){

				
					return;
				};
				if (Password == String.Empty) {


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

