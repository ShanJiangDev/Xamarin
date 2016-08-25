using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;

namespace UsingBroadcasts
{
	// Broadcast:
	// https://developer.android.com/reference/android/content/BroadcastReceiver.html
	// Base class for code that will receive intents sent by sendBroadcast().










	[Activity(Label = "UsingBroadcasts", MainLauncher = true, Icon = "@mipmap/icon")]
	//[BroadcastReceiver(Enabled = true)]
	//[IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted })]
	//[BroadcastReceiver]



	public class MainActivity : Activity
	{

		MyBroadcastReceiver myReceiver;
		IntentFilter intentFilter;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//myReceiver = new MyBroadcastReceiver();
			myReceiver = new MyBroadcastReceiver();
			intentFilter = new IntentFilter("MY_SPECIFIC_ACTION");

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button>(Resource.Id.btnSendBroadcast);

			button.Click += delegate 
			{
				// Send broadcast
				Intent i = new Intent("MY_SPECIFIC_ACTION");
				i.PutExtra("key", "some value from intent");


				// When you use sendBroadcast(Intent)or related methods, normally any other 
				// application can receive these broadcasts.You can control who can receive 
				// such broadcasts through permissions described below.Alternatively, starting
				// with ICE_CREAM_SANDWICH, you can also safely restrict the broadcast to a single 
				// application with Intent.setPackage
				SendBroadcast(i);
			};
		}



		protected override void OnResume()
		{
			base.OnResume();
			// Receive Broadcast

			// Register a BroadcastReceiver to be run in the main activity thread. 
			// The receiver will be called with any broadcast Intent that matches filter, 
			// in the main application thread


			// 1. The Intent namespace is global.Make sure that Intent action names and other 
			//  strings are written in a namespace you own, or else you may inadvertently conflict 
			//  with other applications.
			// 2. When you use registerReceiver(BroadcastReceiver, IntentFilter), any application may
			//  send broadcasts to that registered receiver.You can control who can send broadcasts to 
			//  it through permissions described below.
			// 3. When you publish a receiver in your application's manifest and specify intent-filters 
			//  for it, any other application can send broadcasts to it regardless of the filters you specify.
			//  To prevent others from sending to it, make it unavailable to them with android:exported="false".

			RegisterReceiver(myReceiver, intentFilter);
		}

		protected override void OnPause()
		{
			base.OnPause();
			UnregisterReceiver(myReceiver);
		}

		class MyBroadcastReceiver : BroadcastReceiver
		{
			// Receive broadcast
			public override void OnReceive(Context context, Intent i)
			{
				Toast.MakeText(context, "Received broadcast in MyBroadcastReceiver, value received: "
						   + i.GetStringExtra("key"), ToastLength.Long).Show();

				InvokeAbortBroadcast();
		
			}

		}


	}
}


