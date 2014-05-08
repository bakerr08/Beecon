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
	[Activity (Label = "HomeActivity")]			
	public class HomeActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Home);

			// ****Buttons That will be in pull out menu****
			Button CreateBeecon = FindViewById<Button> (Resource.Id.btnCreate);
			Button Friends = FindViewById<Button> (Resource.Id.btnFriends);
			Button Leaderboard = FindViewById<Button> (Resource.Id.btnLeaderborad);
			//Button Settings = FindViewById<Button> (Resource.Id.btnSettings);
			//******************************************************************


			//Pull in Map View

			//Show Beecons



			//******************************************************************
			// On Click Events for specific Buttons
			CreateBeecon.Click += (sender, e) =>  {
				StartActivity (typeof(CreateActivity));
			};
			Friends.Click += (sender, e) =>  {
				StartActivity (typeof(FriendActivity));
			};
			Leaderboard.Click += (sender, e) =>  {
				StartActivity (typeof(LeaderboardActivity));
			};
		}
	}
}

