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
	[Activity (Label = "CreateActivity")]			
	public class CreateActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Create);

			Button TakePhoto = FindViewById<Button> (Resource.Id.btnCapture);

			TakePhoto.Click += delegate {
				// Capture Photo Code
			};

		}
	}
}

