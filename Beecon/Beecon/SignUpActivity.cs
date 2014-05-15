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
using Beecon.Models2;
namespace Beecon
{
	[Activity (Label = "SignUpActivity")]			
	public class SignUpActivity : Activity
	{
		String FirstName = (Resource.Id.txtFirstName.ToString());
		String LastName = (Resource.Id.txtLastName.ToString ());
		String Email = (Resource.Id.txtEmailSignUp.ToString ());
		String Password = (Resource.Id.txtPasswordSignUp.ToString ());
		String DoB = (Resource.Id.txtDOB.ToString ());
		//String Gender;
		EditText txtFirstName = null;
		EditText txtLastName = null;
		EditText txtEmailSignUp = null;
		EditText txtPasswordSignUp = null;
		TextView txtDOB = null;
		TextView lblDoB = null;
		RadioButton rbMale = null;
		RadioButton rbFemale = null;
		private DateTime _UserBday;
		private cUser oUser = new cUser();
		const int DATE_DIALOG_ID = 0;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SignUp);
			txtFirstName = FindViewById<EditText> (Resource.Id.txtFirstName);
			txtLastName = FindViewById<EditText> (Resource.Id.txtLastName);
			txtEmailSignUp = FindViewById<EditText> (Resource.Id.txtEmailSignUp);
			txtPasswordSignUp = FindViewById<EditText> (Resource.Id.txtPasswordSignUp);
			txtDOB = FindViewById<TextView> (Resource.Id.txtDOB);
			Button btnSubmit = FindViewById<Button> (Resource.Id.btnSubmit);
			//dobPicker = FindViewById<DatePicker> (Resource.Id.dobPicker);
			Button btnChooseDate = FindViewById<Button> (Resource.Id.btnChooseDate);
			// User Information
			String FirstName = (Resource.Id.txtFirstName.ToString());
			String LastName = (Resource.Id.txtLastName.ToString ());
			String Email = (Resource.Id.txtEmailSignUp.ToString ());
			String Password = (Resource.Id.txtPasswordSignUp.ToString ());
			String DoB = (Resource.Id.txtDOB.ToString ());


			btnChooseDate.Click += delegate { ShowDialog (DATE_DIALOG_ID); };
			rbMale = FindViewById<RadioButton>(Resource.Id.rbMale); 
			rbFemale = FindViewById<RadioButton>(Resource.Id.rbFemale); 
			rbMale.Click += RadioButtonMaleClick;
			rbFemale.Click += RadioButtFemaleClick;

			// Submitting new sign up code
			btnSubmit.Click += delegate 
			{
				Submit();
				// Submitting new sign up code



			};
			// get the current date
			_UserBday = DateTime.Today;

			// display the current date (this method is below)
			UpdateDisplay ();
		}
		private void RadioButtonMaleClick (object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Toast.MakeText (this, rb.Text, ToastLength.Short).Show ();
		} 
		private void RadioButtFemaleClick (object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			Toast.MakeText (this, rb.Text, ToastLength.Short).Show ();
		}
		private void UpdateDisplay ()
		{
			lblDoB.Text = _UserBday.ToString ("d");
		}
		// the event received when the user "sets" the date in the dialog
		void OnDateSet (object sender, DatePickerDialog.DateSetEventArgs e)
		{
			this._UserBday = e.Date;
			UpdateDisplay ();
		}
		protected void Submit()
		{

			oUser.FirstName = (Resource.Id.txtFirstName.ToString ());
			oUser.LastName = (Resource.Id.txtLastName.ToString ());
			oUser.Email = (Resource.Id.txtEmailSignUp.ToString ());
			oUser.Password = (Resource.Id.txtPasswordSignUp.ToString ());
			DateTime dob = _UserBday;
			oUser.Dob = (new DateTime ());
			//String Gender;s
			if (rbMale.Checked == true) {
				oUser.Gender = "Male";
			} else if (rbFemale.Checked == true) {
				oUser.Gender = "Female";
			}
			string json;
			json = oUser.ConvertToJson (oUser);
			oUser.PostDataWithOperation ("signup", json);
		}

	}
}

