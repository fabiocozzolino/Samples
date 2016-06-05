using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;

namespace CloudFace.Client
{
	public class FaceClient
	{
		public FaceClient ()
		{
		}

		public async Task<Face[]> DetectAsync(Stream stream)
		{
			var returnFaceId = true;
			var returnFaceLandmarks = true;
			var returnFaceAttributes = "age,gender,smile,facialHair,headPose,glasses";
			var url = $"https://api.projectoxford.ai/face/v1.0/detect?returnFaceId={returnFaceId}&returnFaceLandmarks={returnFaceLandmarks}&returnFaceAttributes={returnFaceAttributes}";

			var requestContent = new StreamContent (stream);
			requestContent.Headers.Add ("Ocp-Apim-Subscription-Key", SubscriptionKeys.FaceId);
			requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ("application/octet-stream");
			var client = new HttpClient ();
			var response = await client.PostAsync (url, requestContent);

			var responseContent = response.Content as StreamContent;
			var jsonResponse = await responseContent.ReadAsStringAsync ();

			return JsonConvert.DeserializeObject<Face[]> (jsonResponse);
		}
	}


	public class FaceRectangle
	{
		public int top { get; set; }
		public int left { get; set; }
		public int width { get; set; }
		public int height { get; set; }
	}

	public class PupilLeft
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class PupilRight
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseTip
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class MouthLeft
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class MouthRight
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyebrowLeftOuter
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyebrowLeftInner
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeLeftOuter
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeLeftTop
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeLeftBottom
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeLeftInner
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyebrowRightInner
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyebrowRightOuter
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeRightInner
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeRightTop
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeRightBottom
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class EyeRightOuter
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseRootLeft
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseRootRight
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseLeftAlarTop
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseRightAlarTop
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseLeftAlarOutTip
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class NoseRightAlarOutTip
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class UpperLipTop
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class UpperLipBottom
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class UnderLipTop
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class UnderLipBottom
	{
		public double x { get; set; }
		public double y { get; set; }
	}

	public class FaceLandmarks
	{
		public PupilLeft pupilLeft { get; set; }
		public PupilRight pupilRight { get; set; }
		public NoseTip noseTip { get; set; }
		public MouthLeft mouthLeft { get; set; }
		public MouthRight mouthRight { get; set; }
		public EyebrowLeftOuter eyebrowLeftOuter { get; set; }
		public EyebrowLeftInner eyebrowLeftInner { get; set; }
		public EyeLeftOuter eyeLeftOuter { get; set; }
		public EyeLeftTop eyeLeftTop { get; set; }
		public EyeLeftBottom eyeLeftBottom { get; set; }
		public EyeLeftInner eyeLeftInner { get; set; }
		public EyebrowRightInner eyebrowRightInner { get; set; }
		public EyebrowRightOuter eyebrowRightOuter { get; set; }
		public EyeRightInner eyeRightInner { get; set; }
		public EyeRightTop eyeRightTop { get; set; }
		public EyeRightBottom eyeRightBottom { get; set; }
		public EyeRightOuter eyeRightOuter { get; set; }
		public NoseRootLeft noseRootLeft { get; set; }
		public NoseRootRight noseRootRight { get; set; }
		public NoseLeftAlarTop noseLeftAlarTop { get; set; }
		public NoseRightAlarTop noseRightAlarTop { get; set; }
		public NoseLeftAlarOutTip noseLeftAlarOutTip { get; set; }
		public NoseRightAlarOutTip noseRightAlarOutTip { get; set; }
		public UpperLipTop upperLipTop { get; set; }
		public UpperLipBottom upperLipBottom { get; set; }
		public UnderLipTop underLipTop { get; set; }
		public UnderLipBottom underLipBottom { get; set; }
	}

	public class HeadPose
	{
		public double pitch { get; set; }
		public double roll { get; set; }
		public double yaw { get; set; }
	}

	public class FacialHair
	{
		public double moustache { get; set; }
		public double beard { get; set; }
		public double sideburns { get; set; }
	}

	public class FaceAttributes
	{
		public double smile { get; set; }
		public HeadPose headPose { get; set; }
		public string gender { get; set; }
		public double age { get; set; }
		public FacialHair facialHair { get; set; }
		public string glasses { get; set; }
	}

	public class Face
	{
		public string faceId { get; set; }
		public FaceRectangle faceRectangle { get; set; }
		public FaceLandmarks faceLandmarks { get; set; }
		public FaceAttributes faceAttributes { get; set; }
	}

}

