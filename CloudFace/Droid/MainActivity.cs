using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using CloudFace.Droid;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Device;

[assembly: Dependency(typeof(ImageResizer))]
[assembly: Dependency(typeof(MediaPicker))]
[assembly: Dependency(typeof(AndroidDevice))]
[assembly: Dependency(typeof(AudioRecorder))]

namespace CloudFace.Droid
{
	[Activity (Label = "CloudFace.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsAppCompatDroid
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}
	}
}

