using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;

namespace UsingBroadcasts
{

	[Activity(Label = "UsingBroadcasts", MainLauncher = true, Icon = "@mipmap/icon")]
	//[BroadcastReceiver(Enabled = true)]
	//[IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted })]
	//[BroadcastReceiver]



	public class MainActivity : Activity
	{
		MyBroadcastReceiver myBroadcastReceiver;





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
				Intent i = new Intent("MY_SPECIFIC_ACTION");
				i.PutExtra("key", "some value from intent");
				SendBroadcast(i);
			};
		}



		protected override void OnResume()
		{
			base.OnResume();
			RegisterReceiver(myReceiver, intentFilter);
		}

		protected override void OnPause()
		{
			base.OnPause();
			UnregisterReceiver(myReceiver);
		}

		class MyBroadcastReceiver : BroadcastReceiver
		{
			public override void OnReceive(Context context, Intent i)
			{
				Toast.MakeText(context, "Received broadcast in MyBroadcastReceiver, value received: "
						   + i.GetStringExtra("key"), ToastLength.Long).Show();

				InvokeAbortBroadcast();
		
			}

		}


	}
}


