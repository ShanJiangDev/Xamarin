
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
			//Some device configurations can change during runtime (such as screen orientation, 
			//keyboard availability, and language). When such a change occurs, Android restarts 
			//the running Activity (onDestroy() is called, followed by onCreate()). The restart 
			//behavior is designed to help your application adapt to new configurations by 
			//automatically reloading your application with alternative resources that match 
			//the new device configuration.

			//To properly handle a restart, it is important that your activity restores its previous 
			//state through the normal Activity lifecycle, in which Android calls onSaveInstanceState()
			//before it destroys your activity so that you can save data about the application state.
			//You can then restore the state during onCreate() or onRestoreInstanceState().

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

