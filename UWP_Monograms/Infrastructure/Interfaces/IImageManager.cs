﻿using System.Drawing;
using System.Threading.Tasks;

namespace UWP_Monograms.Infrastructure.Interfaces
{
	public interface IImageManager
	{
		Task<Color[,]> GetImage(string path);
	}
}
