using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AppSharing
// Sharing data with other app
// https://developer.android.com/training/sharing/send.html
{
	[Activity(Label = "AppSharing", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			FindViewById<Button> (Resource.Id.btnMakeCalls).Click += delegate {
				// Redirect to dia panel with certain number ready to call
				Intent i = new Intent(Intent.ActionDial);
				// a. Add data to Intent
				i.SetData(Android.Net.Uri.Parse("tel: 123456789"));
				// b. Start activity with intent data
				StartActivity(i);
			};

			FindViewById<Button>(Resource.Id.btnViewMaps).Click += delegate
			{
				// Redirect to google map with certain geolocation
				Intent i = new Intent(Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("geo:27.827500, -122.481670"));
				StartActivity(i);
			};

			FindViewById<Button>(Resource.Id.btnSendText).Click += delegate
			{
				Intent i = new Intent(Intent.ActionSend);
				i.SetType("text/plain");
				i.PutExtra(Intent.ExtraSubject, "Subject...");
				i.PutExtra(Intent.ExtraText, "Text...");
				StartActivity(Intent.CreateChooser(i,"Share via..."));
			};

			FindViewById<Button>(Resource.Id.btnViewWebPage).Click += delegate
			{
				// Open browser with certain url
				Intent i = new Intent(Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("https://www.google.se"));
				StartActivity(i);
			};

			FindViewById<Button>(Resource.Id.btnGooglePlay).Click += delegate
			{
				
				Intent i = new Intent(Intent.ActionView);
				i.SetData(Android.Net.Uri.Parse("market://details?id=com.zinio.mobile.android.reader"));
				StartActivity(i);
			};

			FindViewById<Button>(Resource.Id.btnSendEmail).Click += delegate
			{
				// Sent email
				Intent i = new Intent(Intent.ActionSend);
				i.SetData(Android.Net.Uri.Parse("milto:"));
				String[] to = { "someone1@example.com", "someone2@example.com" };
				String[] cc = { "someone3@example.com", "someone4@example.com" };
				i.PutExtra(Intent.ExtraEmail, to);
				i.PutExtra(Intent.ExtraCc, cc);
				i.PutExtra(Intent.ExtraSubject, "Subject here...");
				i.PutExtra(Intent.ExtraText, "Message here...");
				i.SetType("message/rfc822");
				StartActivity(Intent.CreateChooser(i, "Email"));
			};

			FindViewById<Button>(Resource.Id.btnSendBinary).Click += delegate
			{
				// Sent Binary content
				Android.Net.Uri uriToImage = Android.Net.Uri.Parse("android.resource://" + PackageName +
																   "/drawable/" + Convert.ToString(Resource.Drawable.Icon));
				
				Intent i = new Intent(Intent.ActionSend);
				i.SetType("image/jpeg");

				i.PutExtra(Intent.ExtraStream, uriToImage);
				i.PutExtra(Intent.ExtraText, "Text...");
				StartActivity(Intent.CreateChooser(i, "Share via..."));
			};
		}
	}
}


