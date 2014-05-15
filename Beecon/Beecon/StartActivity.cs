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
using Newtonsoft.Json;
using Beecon.Models2;


namespace Beecon
{
	[Activity (Label = "StartActivity", MainLauncher = true)]			
	public class StartActivity : Activity
	{
		protected cUser oUser = new cUser ();
		//
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Start);

			Button btnSignIn = FindViewById<Button> (Resource.Id.btnSignIn);
			Button btnSignUp = FindViewById<Button> (Resource.Id.btnSignUp);
			TextView InputError = FindViewById<TextView> (Resource.Id.InputError);
			EditText txtEmail = FindViewById<EditText> (Resource.Id.txtEmail);
			EditText txtPassword = FindViewById<EditText> (Resource.Id.txtPassword);
			btnSignIn.Click += (sender, e) => {           
				//var second = new Intent(this, typeof(SecondActivity));
				//second.PutExtra("FirstData", "Data from FirstActivity");
				//StartActivity (second);
				cUser User = new cUser();
				User.Email = "nfpobcv.nrmsx@gcgaur.net";
				User.Password = "3QJ3UFZHFOVJ616G32816FD4XF";
				Dictionary<string, string> dict = new Dictionary<string,string>();
				dict.Add("email", User.Email);
				dict.Add("password", User.Password);
				string json = JsonConvert.SerializeObject (dict, Formatting.Indented);
				//User.PostDataWithOperation("SignIn", json);

				var userIntent = new Intent(this, typeof(MainActivity));
				userIntent.PutExtra("User", JsonConvert.SerializeObject (User));
				StartActivity(userIntent);
			};

					

		}


	}
}

