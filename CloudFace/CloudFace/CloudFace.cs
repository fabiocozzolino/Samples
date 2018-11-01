using System;

using Xamarin.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using CloudFace.Client;
using CloudFace.Services;
using XLabs.Platform.Services.Media;
using System.Threading.Tasks;
using CloudFace.Views;
using Services;
using System.Linq;
using XLabs.Ioc;

namespace CloudFace
{
	public class App : Application
	{
		//private const int BUTTON_BORDER_WIDTH = 1;
		//private const int BUTTON_HEIGHT = 88;
		//private const int BUTTON_HEIGHT_WP = 144;
		//private const int BUTTON_HALF_HEIGHT = 44;
		//private const int BUTTON_HALF_HEIGHT_WP = 72;
		//private const int BUTTON_WIDTH = 88;
		//private const int BUTTON_WIDTH_WP = 144;

		//private AbsoluteLayout bodyLayout;
		//private StackLayout bottomLayout;
		//private StackLayout descriptionLayout;
		//private Image image = new Image();
		//private ActivityIndicator indicator = new ActivityIndicator();
		//private Label imageDescription = new Label ();

		//private byte[] imageBuffer;
		//private bool faceDetected = false;
		//private bool emotionDetected = false;

		public App ()
		{

//			bodyLayout = new AbsoluteLayout ();
//			bodyLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
//			bodyLayout.VerticalOptions = LayoutOptions.CenterAndExpand;
//			bodyLayout.Children.Add (image);

//			descriptionLayout = new StackLayout ();
//			descriptionLayout.IsVisible = false;
//			descriptionLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
//			descriptionLayout.VerticalOptions = LayoutOptions.CenterAndExpand;
//			imageDescription.TextColor = Color.Black;
//			imageDescription.HorizontalOptions = LayoutOptions.CenterAndExpand;
//			imageDescription.HorizontalTextAlignment = TextAlignment.Center;
//			imageDescription.Text = "descrivimi l'immagine";
//			var describeTap = new TapGestureRecognizer ();
//			describeTap.Tapped += async (sender, e) => {
//				OnStartLongProcess ();
//				var visionClient = new ComputerVisionClient ();
//				var result = await visionClient.RecognizeAsync (new MemoryStream (imageBuffer));
//				imageDescription.Text = result.description.captions.FirstOrDefault()?.text;
//				OnEndLongProcess ();
//			};
//			imageDescription.GestureRecognizers.Add(describeTap);
//			descriptionLayout.Children.Add (imageDescription);

//			bottomLayout = new StackLayout ();
//			bottomLayout.Orientation = StackOrientation.Horizontal;
//			bottomLayout.HorizontalOptions = LayoutOptions.Center;

//			var button = new Button ()
//			{ 
//				Image = "Camera-50.png",
//				BackgroundColor = Color.Blue,
//				BorderColor = Color.White,
//				TextColor = Color.White,
//				BorderWidth = BUTTON_BORDER_WIDTH,
//				BorderRadius = Device.OnPlatform(BUTTON_HALF_HEIGHT, BUTTON_HALF_HEIGHT, BUTTON_HALF_HEIGHT_WP),
//				HeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP),
//				MinimumHeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP),
//				WidthRequest = Device.OnPlatform(BUTTON_WIDTH, BUTTON_WIDTH, BUTTON_WIDTH_WP),
//				MinimumWidthRequest = Device.OnPlatform(BUTTON_WIDTH, BUTTON_WIDTH, BUTTON_WIDTH_WP),
//				HorizontalOptions = LayoutOptions.Center,
//				VerticalOptions = LayoutOptions.Center
//			};	
//			button.Clicked += TakePictureButtonClicked;

////			var button2 = new Button ()
////			{ 
////				Image = "Camera-50.png",
////				BackgroundColor = Color.Blue,
////				BorderColor = Color.White,
////				TextColor = Color.White,
////				BorderWidth = BUTTON_BORDER_WIDTH,
////				BorderRadius = Device.OnPlatform(BUTTON_HALF_HEIGHT, BUTTON_HALF_HEIGHT, BUTTON_HALF_HEIGHT_WP),
////				HeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP),
////				MinimumHeightRequest = Device.OnPlatform(BUTTON_HEIGHT, BUTTON_HEIGHT, BUTTON_HEIGHT_WP),
////				WidthRequest = Device.OnPlatform(BUTTON_WIDTH, BUTTON_WIDTH, BUTTON_WIDTH_WP),
////				MinimumWidthRequest = Device.OnPlatform(BUTTON_WIDTH, BUTTON_WIDTH, BUTTON_WIDTH_WP),
////				HorizontalOptions = LayoutOptions.Center,
////				VerticalOptions = LayoutOptions.Center
////			};	
////			button2.Clicked += SpeechButtonClicked;
//			bottomLayout.Children.Add (button);
////			bottomLayout.Children.Add (button2);

//			var imageTap = new TapGestureRecognizer ();
//			imageTap.Tapped += async (sender, e) => {

//				OnStartLongProcess ();
//				if (!faceDetected){
//					faceDetected = true;
//					await DetectFace (new MemoryStream (imageBuffer));
//				} else if (!emotionDetected) {
//					emotionDetected = true;
//					await RecognizeEmotion(new MemoryStream(imageBuffer));
//				}
//				OnEndLongProcess ();

//			};
//			image.GestureRecognizers.Add (imageTap);

//			indicator.HorizontalOptions = LayoutOptions.CenterAndExpand;
//			indicator.VerticalOptions = LayoutOptions.CenterAndExpand;

//			var content = new Grid ();
//			content.RowDefinitions.Add (new RowDefinition () { Height = new GridLength(1, GridUnitType.Star) });
//			content.RowDefinitions.Add (new RowDefinition () { Height = 100 });
//			content.RowDefinitions.Add (new RowDefinition () { Height = 100 });
//			content.Children.Add (bodyLayout);
//			content.Children.Add (descriptionLayout);
//			content.Children.Add (bottomLayout);
//			content.Children.Add (indicator);

//			Grid.SetRow (bodyLayout, 0);
//			Grid.SetRow (descriptionLayout, 1);
//			Grid.SetRow (bottomLayout, 2);
//			Grid.SetRow (indicator, 0);
//			Grid.SetRowSpan (indicator, 3);

			MainPage = new CameraPage();
		}

		//async void TakePictureButtonClicked (object sender, EventArgs e)
		//{
		//	var picker = DependencyService.Get<IMediaPicker>();
		//	var mediaFile = await picker.TakePhotoAsync(new CameraMediaStorageOptions {
		//		DefaultCamera = CameraDevice.Front
		//	});

		//	imageBuffer = ResizeToFit (mediaFile);
		//	image.Source = ImageSource.FromStream (() => new MemoryStream (imageBuffer));

		//	descriptionLayout.IsVisible = true;
		//	faceDetected = false;
		//	emotionDetected = false;
		//}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		//void OnStartLongProcess ()
		//{
		//	bodyLayout.BackgroundColor = Color.Black;
		//	bodyLayout.Opacity = 0.5;
		//	indicator.IsVisible = indicator.IsRunning = true;
		//}

		//void OnEndLongProcess ()
		//{
		//	indicator.IsVisible = indicator.IsRunning = false;
		//	bodyLayout.BackgroundColor = Color.Transparent;
		//	bodyLayout.Opacity = 1;
		//}

		//static byte[] ResizeToFit (MediaFile mediaFile)
		//{
		//	var sourceStream = new MemoryStream ();
		//	mediaFile.Source.CopyTo (sourceStream);
		//	sourceStream.Position = 0;
		//	var device = Resolver.Resolve<XLabs.Platform.Device.IDevice> ();
		//	var maxWidth = device.Display.Width;
		//	var maxHeight = device.Display.Height;
		//	var sourceSize = new Size (mediaFile.Exif.Width, mediaFile.Exif.Height);
		//	var maxResizeFactor = Math.Max (maxWidth / sourceSize.Width, maxHeight / sourceSize.Height);
		//	var width = (float)(maxResizeFactor * sourceSize.Width);
		//	var height = (float)(maxResizeFactor * sourceSize.Height);
		//	var buffer = DependencyService.Get<IImageResizer> ().Resize (sourceStream.ToArray (), width, height);
		//	return buffer;
		//}

		//private async Task DetectFace (Stream inputImage)
		//{
		//	foreach (var item in bodyLayout.Children) {
		//		if (item != image)
		//			bodyLayout.Children.Remove (item);
		//	}

		//	var client = new FaceClient ();
		//	var faces = await client.DetectAsync (inputImage);
		//	foreach (var item in faces) {

		//		var layout = new StackLayout ();

		//		var box = new ShapeView ();
		//		box.ShapeType = ShapeType.Box;
		//		box.WidthRequest = (item.faceRectangle.width + 20) / 2;
		//		box.HeightRequest = (item.faceRectangle.height + 20) / 2;
		//		box.Color = Color.Transparent;
		//		box.BackgroundColor = Color.Transparent;
		//		box.StrokeColor = item.faceAttributes.gender == "male" ? Color.FromRgb(49,124,239) : Color.Fuchsia;
		//		box.StrokeWidth = 4;
		//		box.Padding = new Thickness (0);

		//		var attributesLayout = new StackLayout ();
		//		attributesLayout.BackgroundColor = box.StrokeColor;
		//		attributesLayout.Padding = new Thickness (2);

		//		var attributesLabel = new Label ();
		//		attributesLabel.TextColor = Color.White;
		//		attributesLabel.Text = item.faceAttributes.gender + ", " + item.faceAttributes.age;

		//		attributesLayout.Children.Add (attributesLabel);

		//		layout.Children.Add (box);
		//		layout.Children.Add (attributesLayout);

		//		bodyLayout.Children.Add (layout, new Point ((item.faceRectangle.left - 10) / 2, ((item.faceRectangle.top - 10) / 2) - 20));
		//	}
		//}

		//private async Task RecognizeEmotion (Stream ms2)
		//{
		//	var client = new EmotionClient ();
		//	var response = await client.RecognizeAsync (ms2);
		//	foreach (var item in response) {

		//		var layout = new StackLayout ();

		//		var attributesLayout = new StackLayout ();
		//		attributesLayout.BackgroundColor = Color.Blue;


		//		var emotions = new [] {
		//			new { key = "sembra arrabbiato", value = item.scores.anger },
		//			new { key = "disprezza il mondo!", value =  item.scores.contempt },
		//			new { key = "è disgustato", value =  item.scores.disgust },
		//			new { key = "ha paura", value =  item.scores.fear },
		//			new { key = "è felice", value =  item.scores.happiness },
		//			new { key = "indifferente", value =  item.scores.neutral },
		//			new { key = "è triste", value =  item.scores.sadness },
		//			new { key = "sembra sorpreso", value =  item.scores.surprise }
		//		};


		//		var attributesLabel = new Label ();
		//		attributesLabel.TextColor = Color.White;
		//		attributesLabel.Text = emotions.FirstOrDefault(e => e.value == emotions.Max(em => em.value))?.key;

		//		attributesLayout.Children.Add (attributesLabel);

		//		layout.Children.Add (attributesLayout);

		//		bodyLayout.Children.Add (layout, new Point ((item.faceRectangle.left - 10) / 2, ((item.faceRectangle.top - 10) / 2) - 20));
		//	}
		//}
	}
}

//			string filePath = "audio.wav";
//			var recorder = DependencyService.Get<IAudioRecorder> ();
//
//
//			var button1 = new Button ();
//			button1.Text = "Dimmi pure";
//			button1.Clicked += async (sender, e) => {
//
//				if (button1.Text == "Dimmi pure"){
//					button1.Text = "Ti sto ascoltando...";
//					recorder.Start(filePath);
//				}
//				else if (button1.Text == "Ti sto ascoltando..."){
//					button1.Text = "Dimmi pure";
//
//					var buffer = recorder.Stop();
//
//					try {
//
//						var client = new CloudFace.Client.SpeechRecognitionClient();
//						await client.DetectAsync(new MemoryStream(buffer));
//
////						var dataClient = Microsoft.ProjectOxford.SpeechRecognition.SpeechRecognitionServiceFactory.CreateDataClientWithIntent("it-IT", "6d2792eed31b44fab5e12e95b8bec442","60fd198682864193b656261026945d12","376029e7-c3c0-45b4-b6e2-14f6c042adac","4af962f037194f89ad3186ba57ff4fba");
////						dataClient.OnResponseReceived += DataClient_OnResponseReceived;
////						dataClient.SendAudio(buffer,buffer.Length);
//						
//					} catch (Exception ex) {
//						await MainPage.DisplayAlert("error", ex.Message, "cancel");
//					}
//				}
//
//			};

