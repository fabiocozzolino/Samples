using System;
using Xamarin.Forms;
using CloudFace.Views;
using CloudFace.Droid.Renderers;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer (typeof(ShapeView), typeof(ShapeRenderer))]

namespace CloudFace.Droid.Renderers
{
	public class ShapeRenderer : ViewRenderer<ShapeView, Shape>
	{
		public ShapeRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<ShapeView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || this.Element == null)
				return;

			SetNativeControl (new Shape (Resources.DisplayMetrics.Density, Context) {
				ShapeView = Element
			});
		}
	}
}

