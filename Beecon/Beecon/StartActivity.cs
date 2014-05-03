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
	[Activity (Label = "StartActivity")]			
	public class StartActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Start);

			Button SignIn = FindViewById<Button> (Resource.Id.btnSignIn);
			var SignUp = FindViewById<Button> (Resource.Id.btnSignUp);
			TextView txtError = FindViewById<TextView> (Resource.Id.InputError);
			String Email = (Resource.Id.txtEmail.ToString());
			String Password = (Resource.Id.txtPassword.ToString());
			String TextError = (Resource.Id.InputError.ToString());

			//create a user and get it's email and password
			cUser User = new cUser();
			User.Email = Email;
			User.Password = Password;

			//put that email and password into a dictionary 
			Dictionary<string, string> dict = new Dictionary<string,string>();
			dict.Add("email", User.Email);
			dict.Add("password", User.Password);

			// serialize that dictionary into JSON
			dict = JsonConvert.SerializeObject (dict);

			SignIn.Click += delegate {
				//Error Handling
				if (Email == String.Empty){				
					return;
				};
				if (Password == String.Empty) {
					return;
				};

				//Sign In Code
				//call the PostData method that posts the JSON to the service
				string result = cUser.PostDataWithOperation("SingIn", dict);
				//check that the JSON response is valid
				if(result == "Success")
				{
					dict = JsonConvert.DeserializeObject (dict);
					//reserialize the object to pass it to the next activity
					//dict already contraints email and password
					dict.Add("user_id", User.Id);
					dict.Add("firstname", User.FirstName);
					dict.Add("lastname", User.LastName);
					dict.Add("zip", User.Zip);
					dict.Add("dob", User.Dob);
					dict.Add("gender", User.Gender);
					dict.Add("address", User.Address);

					var userIntent = new Intent(this, typeof(MainActivity));
					userIntent.PutExtra("User", JsonConvert.SerializeObject (dict));
					StartActivity(userIntent);
				}
				else
				{
					//display error message
					//txtError.Text = cUser.PostDataWithOperation("SingIn", dict);
					ErrorsBox();
				}

			};
			SignUp.Click += (sender, e) =>  {
				StartActivity (typeof(StartActivity));
			};
		}
		//Error Box Pop up
		private void ErrorsBox(Object, EventArgs e)
		{
			AlertDialog.Builder ErrorMessage;
			ErrorMessage = new AlertDialog.Builder(this);
			ErrorMessage.SetTitle("Error");
			ErrorMessage.SetMessage("The email or passowrd you entered is incorrect. Please try again");
			ErrorMessage.SetCancelable(false);
			ErrorMessage.SetPositiveButton("OK", delegate { Finish();});
			ErrorMessage.Show();
		}
	}
}

