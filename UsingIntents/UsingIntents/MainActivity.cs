using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Content.PM;
using System.Collections.Generic;

namespace UsingIntents
{
	[Activity(Label = "FirstView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		// Checking the availability of an intent
		public static bool IsIntentAvailable(Context context, String action) 
		{
			//Context(Object):
			// Interface to global information about an application environment.
			// This is an abstract class whose implementation is provided by the 
			// Android system. It allows access to application-specific resources 
			// and classes, as well as up-calls for application-level operations 
			// such as launching activities, broadcasting and receiving intents, etc.

			//PackageManager(Object):
			// Class for retrieving various kinds of information related to the 
			// application packages that are currently installed on the device. 
			// You can find this class through getPackageManager(). return global package information.
			PackageManager packageManager = context.PackageManager;
			Intent i = new Intent(action);

			//IList:
			// Represents a collection of objects that can be individually accessed by index.
			// The IList generic interface is a descendant of the ICollection generic 
			// interface and is the base interface of all generic lists.

			//ResolveInfo:
			// Information that is returned from resolving an intent against an IntentFilter. 
			// This partially corresponds to information collected from the AndroidManifest.xml's <intent> tags.
			IList<ResolveInfo> list = packageManager.QueryIntentActivities(
				i, PackageInfoFlags.MatchDefaultOnly);
			return list.Count > 0;
		}


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.btnSecondActivity);

			button.Click += delegate 
			{
				// 1. Call another activity by calling the name of it

				//StartActivity(typeof(SecondActivity));



				// 2. Call another activity by calling "Intent"

				// An Intent is an object that provides runtime binding between separate components 
				// (such as two activities). The Intent represents an app’s "intent to do something."
				// You can use intents for a wide variety of tasks, but in this lesson, your intent 

				// Intent i = new Intent("shan.secondactivity");
				// StartActivity(i);

				// 3. Check if intent is available
				String action = "shan.secondactivity";
				if (IsIntentAvailable(this, action))
				{
					Intent i = new Intent(action);
					StartActivity(Intent.CreateChooser(i, "List of Apps"));
				}
				else 
				{
					Toast.MakeText(this, "Intent not available",
								   ToastLength.Long).Show();
				}

			};
		}
	}
}


