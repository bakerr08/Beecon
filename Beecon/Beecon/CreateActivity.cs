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

			//Xamarin Example to use Camera + write to file
			//http://docs.xamarin.com/recipes/android/other_ux/camera_intent/take_a_picture_and_save_using_camera_app/
		}
	}
}

