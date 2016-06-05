
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CloudFace.iOS;


[assembly: ExportRenderer( typeof( Button ), typeof( ImageButtonRenderer ) )]
namespace CloudFace.iOS
{
	public class ImageButtonRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);
			var imgSize = Control.ImageView.Frame.Size;
			var ctrlSize = Control.Frame.Size;
			var offSet = ((ctrlSize.Width - imgSize.Width) / 2);
			Control.ImageEdgeInsets = new UIEdgeInsets(Control.ImageEdgeInsets.Top, offSet, Control.ImageEdgeInsets.Bottom, offSet);
		}
	}
}