using Android.App;
using Android.Widget;
using Android.OS;

namespace UsingIntents
{
	[Activity(Label = "FirstView", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
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
				// Call another activity by calling the name of it
				StartActivity(typeof(SecondActivity));

			};
		}
	}
}


