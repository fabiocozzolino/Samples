using System;
using Android.Graphics;
using System.IO;
using CloudFace.Services;
using Xamarin.Forms;
using CloudFace.Droid;
using Services;
using Android.Media;
using Android.OS;
using Java.Net;


namespace CloudFace.Droid
{
	public class ImageResizer : IImageResizer
	{
		public byte[] Resize (byte[] imageData, float width, float height)
		{
			// Load the bitmap
			Bitmap originalImage = BitmapFactory.DecodeByteArray (imageData, 0, imageData.Length);
			Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

			using (MemoryStream ms = new MemoryStream())
			{
				resizedImage.Compress (Bitmap.CompressFormat.Jpeg, 100, ms);
				return ms.ToArray ();
			}
		}
	}

	public class AudioRecorder : IAudioRecorder
	{
		MediaRecorder _recorder;
		string _outputFile;

		#region IAudioRecorder implementation
		public void Start (string outputFile)
		{
			_recorder = new MediaRecorder ();
			_outputFile = System.IO.Path.Combine( System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), outputFile);
			_recorder.SetAudioSource (AudioSource.Mic);
			_recorder.SetOutputFormat (OutputFormat.ThreeGpp);
			_recorder.SetAudioEncoder (AudioEncoder.AmrNb);
			_recorder.SetOutputFile (_outputFile);
			_recorder.Prepare ();
			_recorder.Start ();
		}
		public byte[] Stop ()
		{
			_recorder.Stop ();

			return File.ReadAllBytes (_outputFile);
		}
		#endregion
		
	}
}

