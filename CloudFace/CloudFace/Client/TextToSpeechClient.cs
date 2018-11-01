using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using CloudFace.Client;

namespace Client
{
	public interface ITextToSpeech
	{
		void Speak(string text);
	}
}

