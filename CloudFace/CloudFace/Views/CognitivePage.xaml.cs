using System;
using System.Linq;
using Microsoft.ProjectOxford.Face.Contract;
using ViewModels;
using Xamarin.Forms;

namespace CloudFace.Views
{
	public partial class CognitivePage : ContentPage
	{
		public CognitiveViewModel ViewModel
		{
			get
			{
				return BindingContext as CognitiveViewModel;
			}
		}

		public CognitivePage()
		{
			InitializeComponent();

			BindingContext = new CognitiveViewModel();
		}

		public CognitivePage(byte[] image) : this()
		{
			this.ViewModel.Image = image;
			this.ViewModel.PropertyChanged += (sender, e) =>
			{
                if (e.PropertyName == "Faces")
                {
                    UpdateFaces();
                    UpdateEmotions();
                }
			};
		}

		void UpdateEmotions()
		{
			foreach (var item in this.ViewModel.Faces)
			{

				var layout = new StackLayout();

				var attributesLayout = new StackLayout();
				attributesLayout.BackgroundColor = Color.Blue;

                if (item.FaceAttributes.Emotion == null)
                    continue;

				var emotions = new[] {
							new { key = "sembra arrabbiato", value = item.FaceAttributes.Emotion.Anger },
							new { key = "disprezza il mondo!", value =  item.FaceAttributes.Emotion.Contempt },
							new { key = "è disgustato", value =  item.FaceAttributes.Emotion.Disgust },
							new { key = "ha paura", value =  item.FaceAttributes.Emotion.Fear },
							new { key = "è felice", value =  item.FaceAttributes.Emotion.Happiness },
							new { key = "indifferente", value =  item.FaceAttributes.Emotion.Neutral },
							new { key = "è triste", value =  item.FaceAttributes.Emotion.Sadness },
							new { key = "sembra sorpreso", value =  item.FaceAttributes.Emotion.Surprise }
						};


				var attributesLabel = new Label();
				attributesLabel.TextColor = Color.White;
				attributesLabel.Text = emotions.OrderByDescending(em => em.value).Select(em => em.key).FirstOrDefault();

				attributesLayout.Children.Add(attributesLabel);

				layout.Children.Add(attributesLayout);

				bodyLayout.Children.Add(layout, new Point((item.FaceRectangle.Left - 100) / 2, ((item.FaceRectangle.Top - 100) / 2) - 100));
			}
		}

		void UpdateFaces()
		{
			foreach (var item in bodyLayout.Children)
			{
				if (item.GetType() != typeof(Image))
					bodyLayout.Children.Remove(item);
			}

			foreach (var item in this.ViewModel.Faces)
			{

				var layout = new StackLayout();

				var box = new ShapeView();
				box.ShapeType = ShapeType.Box;
				box.WidthRequest = (item.FaceRectangle.Width + 20) / 2 - 80;
				box.HeightRequest = (item.FaceRectangle.Height + 20) / 2;
				box.Color = Color.Transparent;
				box.BackgroundColor = Color.Transparent;
				box.StrokeColor = item.FaceAttributes.Gender == "male" ? Color.FromRgb(49, 124, 239) : Color.Fuchsia;
				box.StrokeWidth = 4;
				box.Padding = new Thickness(0);

				var attributesLayout = new StackLayout();
				attributesLayout.BackgroundColor = box.StrokeColor;
				attributesLayout.Padding = new Thickness(2);

				var attributesLabel = new Label();
				attributesLabel.TextColor = Color.White;
                attributesLabel.Text = (item.FaceAttributes.Gender == "male" ? "maschio" : "femmina") + " di anni " + item.FaceAttributes.Age;
				attributesLayout.Children.Add(attributesLabel);

				var glassesLabel = new Label();
				glassesLabel.TextColor = Color.White;
				glassesLabel.Text = GetGlass(item.FaceAttributes.Glasses);
				attributesLayout.Children.Add(glassesLabel);

				if (item.FaceAttributes.Gender == "male")
				{
					var confidence = new[] { 
						new {c = item.FaceAttributes.FacialHair.Beard, d = "barba"},
						new {c = item.FaceAttributes.FacialHair.Moustache, d = "baffi"},
						new {c = item.FaceAttributes.FacialHair.Sideburns, d = "basette"}
					}.OrderByDescending(c => c.c).First();
					
					var beardLabel = new Label();
					beardLabel.TextColor = Color.White;
					beardLabel.Text = confidence.d;
					attributesLayout.Children.Add(beardLabel);
				}

				layout.Children.Add(box);

				bodyLayout.Children.Add(layout, new Point((item.FaceRectangle.Left - 100) / 2, ((item.FaceRectangle.Top - 100) / 2) - 100));
				bodyLayout.Children.Add(attributesLayout, new Point((item.FaceRectangle.Left - 100) / 2, ((item.FaceRectangle.Top + item.FaceRectangle.Height) / 2) - 140));
			}
		}

		string GetGlass(string glass)
		{
			if (glass == "NoGlasses")
				return "senza occhiali";
			if (glass == "Glasses")
				return "con occhiali";
			if (glass == "ReadingGlasses")
				return "con occhiali da lettura";
			return glass;
		}

		void Handle_Tapped(object sender, System.EventArgs e)
		{
			this.ViewModel.ReadDescription();
		}
	}
}

