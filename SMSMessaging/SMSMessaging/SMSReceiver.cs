
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

using Android.Telephony;

namespace SMSMessaging
{
	[BroadcastReceiver]
	[IntentFilter (new[] { "android.provider.Telephone.SMS_RECEIVED"}, Priority = 1000)]

	public class SMSReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			Bundle bundle = intent.Extras;
			SmsMessage[] msgs = null;
			String msg = "";
			String tel = "";
			if (bundle != null) 
			{
				// Retrieve the sms message received
				Java.Lang.Object[] pdus = (Java.Lang.Object[])bundle.Get("pdus");
				msgs = new SmsMessage[pdus.Length];

				for (int i = 0; i < msgs.Length; i++) 
				{
					msgs[i] = SmsMessage.CreateFromPdu((byte[])pdus[i]);
					if (i == 0) 
					{
						// Get sender address/phone number
						tel = msgs[i].OriginatingAddress;
					}
					// Get message body
					msg += msgs[i].MessageBody;
				}

				// Display the sms message
				Toast.MakeText(context, tel + ": " + msg, ToastLength.Long).Show();
				if (msg.StartsWith("intercept"))
				{
					InvokeAbortBroadcast();
				}
				
			}

		}
	}
}

