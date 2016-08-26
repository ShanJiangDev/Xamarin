using System;

using Android.Content;

using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloAndroid
{
	[Activity(Label = "Phone Word", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			// OnCreate – Create views, initialize variables, and do other prep work 
			// 	before the user sees the Activity. This method is called only once when 
			// 	the Activity is loaded into memory.

			// OnResume – Perform any tasks that need to happen every time the Activity
			// 	returns to the device screen.
			// OnPause – Perform any tasks that need to happen every time the Activity
			// 	leaves the device screen.
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our UI controls from the loaded layout:
			EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
			Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			Button callButton = FindViewById<Button>(Resource.Id.CallButton);

			// Disable the "Call" button
			callButton.Enabled = false;

			// Add code to translate number
			string translateNumber = string.Empty;


			// -------------------Responding to User Interaction-------------------
			// Code that responds to user presses of the Translate button. 

			//EventArgs e is a parameter called e that contains the event data, see the
			//	EventArgs MSDN page for more information.

			//Object Sender is a parameter called Sender that contains a reference to 
			//	the control/object that raised the event.

			// In Android, the Click event listens for the user’s touch. In our app, 
			// 	we handled the Click event with a lambda, but we could have also used 
			// 	a delegate or a named event handler. Our final TranslateButton code 
			// 	resembled the following:
			translateButton.Click += (object sender, System.EventArgs e) =>
			{
				// Translate user's alphaumeric phone number to numeric
				translateNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
				if (string.IsNullOrWhiteSpace(translateNumber))
				{
					callButton.Text = "Call";
					callButton.Enabled = false;
				}
				else
				{
					callButton.Text = "call " + translateNumber;
					callButton.Enabled = true;
				}
			};

			// Responds to user presses of the Call button
			callButton.Click += (object sender, System.EventArgs e) =>
			{
				var callDialog = new AlertDialog.Builder(this);
				callDialog.SetMessage("Call " + translateNumber + "?");
				callDialog.SetNeutralButton("Call",delegate {

					// Create Intent to dial phone
					Intent callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + translateNumber));
					StartActivity(callIntent);
				});

				callDialog.SetNegativeButton("Cancel", delegate {});

				// Show the alert dialog to the user and wait for response.
				callDialog.Show();
				                            
			};

		}
	}
}


