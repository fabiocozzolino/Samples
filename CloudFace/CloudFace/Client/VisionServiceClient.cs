using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CloudFace.Client;
using Microsoft.ProjectOxford.Vision;

namespace Client
{
	public static class VisionServiceClient
	{
		public static async Task<string> AnalyzeAsync(byte[] image)
		{
			var visualFeatures = new VisualFeature[] { VisualFeature.Adult, VisualFeature.Categories, VisualFeature.Color, VisualFeature.Description, VisualFeature.Faces, VisualFeature.ImageType, VisualFeature.Tags };
            var vision = new Microsoft.ProjectOxford.Vision.VisionServiceClient(SubscriptionKeys.ComputerVisionId, "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");
			var result = await vision.AnalyzeImageAsync(new MemoryStream(image) { Position = 0 }, visualFeatures);
			return result.Description.Captions.OrderBy(c => c.Confidence).Select(c => c.Text).FirstOrDefault();
		}
	}
}

