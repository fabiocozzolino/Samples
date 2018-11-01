using System.IO;
using Client;
using CloudFace.Client;
using Xamarin.Forms;
using XLabs.Ioc;

namespace ViewModels
{
	public class CognitiveViewModel : ViewModel
	{
		public byte[] Image
		{
			get
			{
				return GetValue<byte[]>();
			}
			set
			{
				SetValue(value);
			}
		}

		public string ImageDescription
		{
			get
			{
				return GetValue<string>();
			}
			set
			{
				SetValue(value);
			}
		}

		public int ImageWidth
		{
			get
			{
				return Resolver.Resolve<XLabs.Platform.Device.IDevice>().Display.Width;
			}
		}

		public int ImageHeight
		{
			get
			{
				return Resolver.Resolve<XLabs.Platform.Device.IDevice>().Display.Height;
			}
		}

		public Face[] Faces
		{
			get
			{
				return GetValue<Face[]>();
			}
			set
			{
				SetValue(value);
			}
		}

		public Emotion[] EmotionFaces
		{
			get
			{
				return GetValue<Emotion[]>();
			}
			set
			{
				SetValue(value);
			}
		}

		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);

			if (propertyName != null && propertyName == "Image")
			{
				DescribeImage();
				DetectFaceAndEmotions();
			}
		}

		async void DescribeImage()
		{
			this.ImageDescription = await Client.VisionServiceClient.AnalyzeAsync(this.Image);
			ReadDescription();
		}

		async void DetectFaceAndEmotions()
		{
			var face = new FaceClient();
            this.Faces = await face.DetectAsync(new MemoryStream(this.Image) { Position = 0 });



			//var emotion = new EmotionClient();
			//this.EmotionFaces = await emotion.RecognizeAsync(new MemoryStream(this.Image) { Position = 0 });
		}

		public async void ReadDescription()
		{
			DependencyService.Get<ITextToSpeech>().Speak(this.ImageDescription);
		}

		//public async void Video()
		//{
		//	var settings = new Microsoft.ProjectOxford.Video.Contract.VideoStabilizationOperationSettings();

		//	var video = new Microsoft.ProjectOxford.Video.VideoServiceClient("");
		//	var operation = await video.CreateOperationAsync(new MemoryStream(), settings);
		//	var result = await video.GetOperationResultAsync(operation);
		//	var resultVideo = await video.GetResultVideoAsync(operation.Url);


		//}

	}
}