using System;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudFace.Client
{
	public class ComputerVisionClient
	{
		public ComputerVisionClient ()
		{
		}

		public async Task<ImageDescription> RecognizeAsync(Stream stream)
		{
			var url = $"https://api.projectoxford.ai/vision/v1.0/describe";

			var requestContent = new StreamContent (stream);
			requestContent.Headers.Add ("Ocp-Apim-Subscription-Key", SubscriptionKeys.ComputerVisionId);
			requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ("application/octet-stream");
			var client = new HttpClient ();
			var response = await client.PostAsync (url, requestContent);

			var responseContent = response.Content as StreamContent;
			var jsonResponse = await responseContent.ReadAsStringAsync ();

			var serializer = JsonSerializer.Create ();
			var faces = serializer.Deserialize (new StringReader(jsonResponse), typeof(ImageDescription)) as ImageDescription;

			return faces;
		}
	}


	public class Caption
	{
		public string text { get; set; }
		public double confidence { get; set; }
	}

	public class Description
	{
		public List<string> tags { get; set; }
		public List<Caption> captions { get; set; }
	}

	public class Metadata
	{
		public int width { get; set; }
		public int height { get; set; }
		public string format { get; set; }
	}

	public class ImageDescription
	{
		public Description description { get; set; }
		public string requestId { get; set; }
		public Metadata metadata { get; set; }
	}

}

