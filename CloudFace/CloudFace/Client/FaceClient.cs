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
			var returnFaceAttributes = "age,gender,smile,facialHair,headPose,glasses,emotion";
            //var url = $"https://api.projectoxford.ai/face/v1.0/detect?returnFaceId={returnFaceId}&returnFaceLandmarks={returnFaceLandmarks}&returnFaceAttributes={returnFaceAttributes}";
            var url = $"https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId={returnFaceId}&returnFaceLandmarks={returnFaceLandmarks}&returnFaceAttributes={returnFaceAttributes}";
        
            var requestContent = new StreamContent (stream);
			requestContent.Headers.Add ("Ocp-Apim-Subscription-Key", SubscriptionKeys.FaceId);
			requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue ("application/octet-stream");
			var client = new HttpClient ();
			var response = await client.PostAsync (url, requestContent);

			var responseContent = response.Content as StreamContent;
			var jsonResponse = await responseContent.ReadAsStringAsync ();

            return JsonConvert.DeserializeObject<Face[]> (jsonResponse);
		}

		public async Task<Microsoft.ProjectOxford.Face.Contract.Face[]> DetectWithClientAsync(Stream imageStream)
		{
			var client = new Microsoft.ProjectOxford.Face.FaceServiceClient (SubscriptionKeys.FaceId);
			return await client.DetectAsync(imageStream, 
				returnFaceId:true, 
				returnFaceLandmarks:true, 
				returnFaceAttributes: new [] { 
				Microsoft.ProjectOxford.Face.FaceAttributeType.Age,
				Microsoft.ProjectOxford.Face.FaceAttributeType.Gender});
		}
	}


	public class FaceRectangle
	{
		public int Top { get; set; }
		public int Left { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
	}

	public class PupilLeft
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class PupilRight
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseTip
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class MouthLeft
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class MouthRight
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyebrowLeftOuter
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyebrowLeftInner
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeLeftOuter
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeLeftTop
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeLeftBottom
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeLeftInner
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyebrowRightInner
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyebrowRightOuter
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeRightInner
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeRightTop
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeRightBottom
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class EyeRightOuter
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseRootLeft
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseRootRight
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseLeftAlarTop
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseRightAlarTop
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseLeftAlarOutTip
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class NoseRightAlarOutTip
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class UpperLipTop
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class UpperLipBottom
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class UnderLipTop
	{
        public double X { get; set; }
        public double Y { get; set; }
    }

	public class UnderLipBottom
	{
		public double X { get; set; }
		public double Y { get; set; }
	}

	public class FaceLandmarks
	{
		public PupilLeft PupilLeft { get; set; }
		public PupilRight PupilRight { get; set; }
		public NoseTip NoseTip { get; set; }
		public MouthLeft MouthLeft { get; set; }
		public MouthRight MouthRight { get; set; }
		public EyebrowLeftOuter EyebrowLeftOuter { get; set; }
		public EyebrowLeftInner EyebrowLeftInner { get; set; }
		public EyeLeftOuter EyeLeftOuter { get; set; }
		public EyeLeftTop EyeLeftTop { get; set; }
		public EyeLeftBottom EyeLeftBottom { get; set; }
		public EyeLeftInner EyeLeftInner { get; set; }
		public EyebrowRightInner EyebrowRightInner { get; set; }
		public EyebrowRightOuter EyebrowRightOuter { get; set; }
		public EyeRightInner EyeRightInner { get; set; }
		public EyeRightTop EyeRightTop { get; set; }
		public EyeRightBottom EyeRightBottom { get; set; }
		public EyeRightOuter EyeRightOuter { get; set; }
		public NoseRootLeft NoseRootLeft { get; set; }
		public NoseRootRight NoseRootRight { get; set; }
		public NoseLeftAlarTop NoseLeftAlarTop { get; set; }
		public NoseRightAlarTop NoseRightAlarTop { get; set; }
		public NoseLeftAlarOutTip NoseLeftAlarOutTip { get; set; }
		public NoseRightAlarOutTip NoseRightAlarOutTip { get; set; }
		public UpperLipTop UpperLipTop { get; set; }
		public UpperLipBottom UpperLipBottom { get; set; }
		public UnderLipTop UnderLipTop { get; set; }
		public UnderLipBottom UnderLipBottom { get; set; }
	}

	public class HeadPose
	{
		public double Pitch { get; set; }
		public double Roll { get; set; }
		public double Yaw { get; set; }
	}

	public class FacialHair
	{
		public double Moustache { get; set; }
		public double Beard { get; set; }
		public double Sideburns { get; set; }
	}

	public class FaceAttributes
	{
		public double Smile { get; set; }
		public HeadPose HeadPose { get; set; }
		public string Gender { get; set; }
		public double Age { get; set; }
		public FacialHair FacialHair { get; set; }
		public string Glasses { get; set; }
        public Emotion Emotion { get; set; }
    }

    public class Face
	{
		public string FaceId { get; set; }
		public FaceRectangle FaceRectangle { get; set; }
		public FaceLandmarks FaceLandmarks { get; set; }
        public FaceAttributes FaceAttributes { get; set; }
	}

    public class Emotion
    {
        public double Anger { get; set; }
        public double Contempt { get; set; }
        public double Disgust { get; set; }
        public double Fear { get; set; }
        public double Happiness { get; set; }
        public double Neutral { get; set; }
        public double Sadness { get; set; }
        public double Surprise { get; set; }
    }
}

