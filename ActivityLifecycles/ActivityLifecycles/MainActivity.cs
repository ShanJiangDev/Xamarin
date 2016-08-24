using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;

namespace ActivityLifecycles
{
	[Activity(Label = "ActivityLifecycles", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.myButton);

			button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); 
			};

			// Initialize activity
			Console.WriteLine("In OnCreate() now");
		}

		protected override void OnStop()
		{
			// Activity is no longer visiable from onPause()
			base.OnStop();
			Console.WriteLine("In OnStop() now");
		}

		protected override void OnPause()
		{
			// When user leaving activity
			// Another activity comes into the foreground
			base.OnPause();
			Console.WriteLine("In OnPause() now");
		}

		protected override void OnStart()
		{
			// From OnCreate() or OnRestart()
			base.OnStart();
			Console.WriteLine("In OnStart() now");
		}

		protected override void OnResume()
		{
			// User return to the activity from onStart()
			// Ready to interact with user
			base.OnResume();
			Console.WriteLine("In OnResume() now");
		}

		protected override void OnDestroy()
		{
			// This activity is finisheing or being destoryed by system
			base.OnDestroy();
			Console.WriteLine("In OnDestroy() now");
		}

		protected override void OnRestart()
		{
			// User navigates to the activity from OnStop()
			base.OnRestart();
			Console.WriteLine("In OnRestart() now");
		}

	}
}


