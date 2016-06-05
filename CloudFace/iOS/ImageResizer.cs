using System;
using UIKit;
using CoreGraphics;
using System.Drawing;
using CloudFace.iOS;
using Xamarin.Forms;
using CloudFace.Services;

[assembly: Dependency(typeof(ImageResizer))]

namespace CloudFace.iOS
{
	public class ImageResizer : IImageResizer
	{
		public byte[] Resize (byte[] imageData, float maxWidth, float maxHeight)
		{
			UIImage sourceImage = ImageFromByteArray (imageData);
			var sourceSize = sourceImage.Size;
			var maxResizeFactor = (float) Math.Max(maxWidth / sourceSize.Width, maxHeight / sourceSize.Height);
			if (maxResizeFactor > 1) {

//				var rect = new CGRect (0, 0, sourceSize.Width, sourceSize.Height);
//				UIGraphics.BeginImageContext(sourceSize);
//				sourceImage.Draw (rect);
//				UIImage img = UIGraphics.GetImageFromCurrentImageContext();
//				var imageData = img.AsJPEG(0.5);
//				UIGraphicsEndImageContext();
				return sourceImage.AsJPEG (0.5f).ToArray ();
			}


			float width = maxResizeFactor * (float)sourceSize.Width;
			float height = maxResizeFactor * (float)sourceSize.Height;
			UIGraphics.BeginImageContext(new SizeF(width, height));
			sourceImage.Draw(new RectangleF(0, 0, width, height));
			var resultImage = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();

			return resultImage.AsJPEG (0.5f).ToArray ();

		}

		public UIKit.UIImage ImageFromByteArray (byte[] data)
		{
			if (data == null) {
				return null;
			}

			UIKit.UIImage image;
			try {
				image = new UIKit.UIImage (Foundation.NSData.FromArray (data));
			} catch (Exception e) {
				Console.WriteLine ("Image load failed: " + e.Message);
				return null;
			}
			return image;
		}
	}
}

