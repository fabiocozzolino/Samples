using System;
using System.Threading.Tasks;
using System.IO;

namespace Services
{
	public interface IAudioRecorder
	{
		void Start(string outputFile);
		byte[] Stop();
	}
}

