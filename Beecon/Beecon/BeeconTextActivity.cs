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
	[Activity (Label = "BeeconTextActivity")]			
	public class BeeconTextActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.BeeconText);
			Button Submit = FindViewById<Button> (Resource.Id.btnSubmitBeecon);
			String BeeconTxt = (Resource.Id.txtBeeconText);

			if (BeeconTxt == String.Empty)
				return;

			// Take Beecon Text Send Serialize it to JSON and Send it

		}
	}
}

