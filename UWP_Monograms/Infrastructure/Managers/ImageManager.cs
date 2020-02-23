﻿using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

namespace UWP_Monograms.Infrastructure.Managers
{
	public static class ImageManager
	{
		public static async Task<Color[,]> GetImage(string path)
		{
			var imageFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(path);
			var imagestream = await imageFile.OpenStreamForReadAsync();
			var imageDecoder = await BitmapDecoder.CreateAsync(imagestream.AsRandomAccessStream());
			var imagePixelData = await imageDecoder.GetPixelDataAsync();
			var bytes = imagePixelData.DetachPixelData();

			var width = (int)imageDecoder.PixelWidth;
			var height = (int)imageDecoder.PixelHeight;

			var result = new Color[height, width];

			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					var k = (y * width + x) * 4;

					result[y, x] = Color.FromArgb(bytes[k + 3], bytes[k + 2], bytes[k + 1], bytes[k + 0]);
				}
			}

			return result;
		}
	}
}