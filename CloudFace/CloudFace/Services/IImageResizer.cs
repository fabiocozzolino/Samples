using System;

namespace CloudFace.Services
{
	public interface IImageResizer
	{
		byte[] Resize(byte[] imageData, float width, float height);
	}
}

