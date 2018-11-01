using System;
using AVFoundation;
using Client;
using Services;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]

namespace Services
{
	public class TextToSpeechImplementation : ITextToSpeech
	{
		public TextToSpeechImplementation() { }

		public void Speak(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
				return;
			
			var speechSynthesizer = new AVSpeechSynthesizer();

			var speechUtterance = new AVSpeechUtterance(text)
			{
				Rate = AVSpeechUtterance.MaximumSpeechRate / 2,
				Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
				Volume = 0.5f,
				PitchMultiplier = 1.0f
			};

			speechSynthesizer.SpeakUtterance(speechUtterance);
		}
	}
}

