using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Locations;

namespace LocationBasedService
{
	[Activity(Label = "LocationBasedService", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, ILocationListener
	{
		LocationManager lm;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			lm = (LocationManager)GetSystemService(Context.LocationService);
		}

		protected override void OnResume()
		{
			base.OnResume();
			// Test on phone
			lm.RequestLocationUpdates(LocationManager.NetworkProvider,0,0,this);
			// Test on Emulator
			lm.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, this);
		}

		protected override void OnPause()
		{
			base.OnPause();
			lm.RemoveUpdates(this);
		}

		public void OnLocationChanged(Location loc)
		{
			if(loc != null) 
			{
				Toast.MakeText(this, "Location changed: Lat : " + loc.Latitude +
				               " Lng: " + loc.Longitude, ToastLength.Long).Show();
				
			}
		}

		// Needed for ILocationListener
		public void OnProviderDisable(string provider) { }
		public void OnProviderEnable(string provider) { }
		public void OnStatusChanged(string provider, Availability status, Bundle bundle) { }

	}
}


