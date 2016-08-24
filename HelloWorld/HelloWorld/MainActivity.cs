using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloWorld
{
	[Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			EditText txtName = FindViewById<EditText>(Resource.Id.txtName);

			Button btn = FindViewById<Button>(Resource.Id.btnOK);
			btn.Click += delegate {
				Toast.MakeText(this, "Welcome to Xamarin, " + txtName.Text, ToastLength.Long).Show();
			};
		}
	}
}


