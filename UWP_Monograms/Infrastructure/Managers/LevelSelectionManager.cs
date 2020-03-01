using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using UWP_Monograms.Infrastructure.Interfaces;

namespace UWP_Monograms.Infrastructure.Managers
{
	public class LevelSelectionManager : ILevelSelectionManager
	{
		private readonly IImageManager _imageManager;

		public Dictionary<int, string> LevelsDictionary { get; set; }

		public LevelSelectionManager(IImageManager imageManager)
		{
			_imageManager = imageManager;

			InitializeLevels();
		}

		private void InitializeLevels()
		{
			LevelsDictionary = new Dictionary<int, string>();

			AddLevel(@"Assets\Images\1.png");
			AddLevel(@"Assets\Images\2.png");
		}

		public void AddLevel(string path)
		{
			var newIndex = LevelsDictionary.Keys.Count == 0
				? 0
				: LevelsDictionary.Keys.LastOrDefault() + 1;

			LevelsDictionary.Add(newIndex, path);
		}

		public Color[,] GetLevel(int number)
		{
			if (!LevelsDictionary.ContainsKey(number))
			{
				throw new ArgumentException($"Level № {number} doesn't exist.");
			}

			var path = LevelsDictionary[number];
			return Task.Run(async () => await _imageManager.GetImage(path)).Result;
		}
	}
}
