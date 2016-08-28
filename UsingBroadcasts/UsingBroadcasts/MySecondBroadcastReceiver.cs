
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

namespace UsingBroadcasts
{
	[BroadcastReceiver]
	[IntentFilter(new[] {"MY_SPECIFIC_ACTION"})]

	public class MySecondBroadcastReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Toast.MakeText(context, "Received broadcast in MySecondBroadcastReceiver, value received: "
						   + intent.GetStringExtra("key"), ToastLength.Long).Show();
		}
	}
}

