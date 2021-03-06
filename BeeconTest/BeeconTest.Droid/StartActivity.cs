﻿using System;
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
			TextView txtEmail = FindViewById<TextView> (Resource.Id.txtEmail);
			TextView txtPassword = FindViewById<TextView> (Resource.Id.txtPassword);
			//TextView txtError = FindViewById<TextView> (Resource.Id.txtError);
			String Email = (Resource.Id.txtEmail.ToString());
			String Password = (Resource.Id.txtPassword.ToString());
			String TextError = (Resource.Id.InputError.ToString());






			btnSignIn.Click += delegate {
				//Error Handling
				this.SignIn();
			};
			

					
					
				//	}
			//	else
				//	{
					//display error message
					//	string sError = cUser.PostDataWithOperation("SingIn", dict);
					//ErrorsBox(sError);
				//		}

			
			//btnSignUp.Click += (sender, e) =>  {
				StartActivity (typeof(StartActivity));
			//};
		}
		//Error Box Pop up
		private void ErrorsBox(Object o, EventArgs e)
		{
			AlertDialog.Builder ErrorMessage;
			ErrorMessage = new AlertDialog.Builder(this);
			ErrorMessage.SetTitle("Error");
			ErrorMessage.SetMessage("The email or passowrd you entered is incorrect. Please try again");
			ErrorMessage.SetCancelable(false);
			ErrorMessage.SetPositiveButton("OK", delegate { Finish();});
			ErrorMessage.Show();
		}
		private void RadioButtonClick (object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Toast.MakeText (this, rb.Text, ToastLength.Short).Show ();
		} 
	private void SignIn ()
		{
			String Email = (Resource.Id.txtEmail.ToString());
			String Password = (Resource.Id.txtPassword.ToString());
			String TextError = (Resource.Id.InputError.ToString());
			//create a user and get it's email and password
			cUser User = new cUser();
			User.Email = "nfpobcv.nrmsx@gcgaur.net";
			User.Password = "3QJ3UFZHFOVJ616G32816FD4XF";
			//put that email and password into a dictionary 
			Dictionary<string, string> dict = new Dictionary<string,string>();
			dict.Add("email", User.Email);
			dict.Add("password", User.Password);
			// serialize that dictionary into JSON
			string json = JsonConvert.SerializeObject (dict, Formatting.Indented);
			//Sign In Code
			//call the PostData method that posts the JSON to the service
			//string result = User.PostDataWithOperation("SingIn", json);
			User.PostDataWithOperation("SingIn", json);

			//if ((User.Id != null)) 
			//check that the JSON response is valid
			//	if(result == "Success")
			//	{
			//dict = JsonConvert.DeserializeObject (dict);
			//reserialize the object to pass it to the next activity
			//dict already contraints email and password
			dict.Add("user_id", User.Id.ToString());
			dict.Add("firstname", User.FirstName);
			dict.Add("lastname", User.LastName);
			dict.Add("zip", User.Zip);
			dict.Add("dob", User.Dob.ToString());
			dict.Add("gender", User.Gender);
			dict.Add("address", User.Address);
			var userIntent = new Intent(this, typeof(MainActivity));
			userIntent.PutExtra("User", JsonConvert.SerializeObject (User));
			StartActivity(userIntent);
		}
	}
}

