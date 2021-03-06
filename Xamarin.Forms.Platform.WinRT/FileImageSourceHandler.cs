﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

#if WINDOWS_UWP

namespace Xamarin.Forms.Platform.UWP
#else

namespace Xamarin.Forms.Platform.WinRT
#endif
{
	public sealed class FileImageSourceHandler : IImageSourceHandler
	{
		public Task<Windows.UI.Xaml.Media.ImageSource> LoadImageAsync(ImageSource imagesoure, CancellationToken cancellationToken = new CancellationToken())
		{
			Windows.UI.Xaml.Media.ImageSource image = null;
			var filesource = imagesoure as FileImageSource;
			if (filesource != null)
			{
				string file = filesource.File;
				image = new BitmapImage(new Uri("ms-appx:///" + file));
			}

			return Task.FromResult(image);
		}
	}
}