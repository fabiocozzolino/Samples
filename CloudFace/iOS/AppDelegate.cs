using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using CloudFace.iOS;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Device;
using XLabs.Ioc;
using XLabs.Platform.Services;
using CloudFace.Views;
using CloudFace.Renderers;


[assembly:ExportRenderer (typeof(ShapeView), typeof(ShapeRenderer))]

[assembly: Dependency(typeof(ImageResizer))]
[assembly: Dependency(typeof(MediaPicker))]
[assembly: Dependency(typeof(AppleDevice))]

namespace CloudFace.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : XLabs.Forms.XFormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			var container = new SimpleContainer ();
			container.Register<IDevice> (t => AppleDevice.CurrentDevice);
			container.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			container.Register<INetwork>(t=> t.Resolve<IDevice>().Network);
			container.Register<IAudioStream>(t=> t.Resolve<IDevice>().Microphone);

			Resolver.SetResolver (container.GetResolver ());

			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

