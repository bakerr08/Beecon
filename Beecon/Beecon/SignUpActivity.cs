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
	[Activity (Label = "SignUpActivity")]			
	public class SignUpActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUp);

			Button Submit = FindViewById<Button> (Resource.Id.btnSubmit);
			// User Information
			String FirstName = (Resource.Id.txtFirstName.ToString());
			String LastName = (Resource.Id.txtLastName.ToString ());
			String Email = (Resource.Id.txtEmailSignUp.ToString ());
			String Password = (Resource.Id.txtPasswordSignUp.ToString ());
			String DoB = (Resource.Id.txtDOB.ToString ());
			String Geneder;

			RadioButton Male = FindViewById<RadioButton>(Resource.Id.rbMale); 
			RadioButton Female = FindViewById<RadioButton>(Resource.Id.rbFemale); 


			// Submitting new sign up code
			Submit.Click += delegate 
			{
				if (Male.Checked == true)
				{
					Geneder = "Male";
				}
				else if ( Female.Checked == true)
				{
					Geneder = "Female";
				}
				else
				{
					// Error Handling Display message to select Geneder 
				}

				// Submitting new sign up code



			};

		}
	}
}

