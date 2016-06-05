using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace CloudFace.Client
{
	public class EmotionClient
	{
		public EmotionClient ()
		{
		}

		public async Task<EmotionFace[]> RecognizeAsync(Stream stream)
		{
			var url = $"https://api.projectoxford.ai/emotion/v1.0/recognize";

			var requestContent = new StreamContent (stream);
			requestContent.Headers.Add ("Ocp-Apim-Subscription-Key", SubscriptionKeys.EmotionId);
			requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ("application/octet-stream");
			var client = new HttpClient ();
			var response = await client.PostAsync (url, requestContent);

			var responseContent = response.Content as StreamContent;
			var jsonResponse = await responseContent.ReadAsStringAsync ();

			var serializer = JsonSerializer.Create ();
			var faces = serializer.Deserialize (new StringReader(jsonResponse), typeof(EmotionFace[])) as EmotionFace[];

			return faces;
		}
	}

	public class Scores
	{
		public double anger { get; set; }
		public double contempt { get; set; }
		public double disgust { get; set; }
		public double fear { get; set; }
		public double happiness { get; set; }
		public double neutral { get; set; }
		public double sadness { get; set; }
		public double surprise { get; set; }
	}

	public class EmotionFace
	{
		public FaceRectangle faceRectangle { get; set; }
		public Scores scores { get; set; }
	}

}

