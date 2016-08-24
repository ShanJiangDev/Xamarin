
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

namespace UsingIntents
{
	// Main Activity
	[Activity(Label = "SecondActivity")]
	// Second Activity
	[IntentFilter(new[] { "shan.secondactivity" },
				   Categories = new[] { Intent.CategoryDefault })]
	 
	public class SecondActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Second);
			Button button = FindViewById<Button>(Resource.Id.btnClose);

			button.Click += delegate {
				// Distory activity
				Finish();

			};
		}
	}
}

