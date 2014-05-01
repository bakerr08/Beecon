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
	[Activity (Label = "SetProxActivity")]			
	public class SetProxActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.SetProx);

			Button Next = FindViewById<Button> (Resource.Id.btnNext);

			// have to figure out how to be able to pick --SR

			// Default Prox and Date Experation 


			Next.Click += (sender, e) =>  {
				// Switching to add text to Beecon
				StartActivity (typeof(BeeconTextActivity));
			};


		}
	}
}

