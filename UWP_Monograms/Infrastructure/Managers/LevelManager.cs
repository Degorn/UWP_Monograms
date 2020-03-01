using System;
using System.Drawing;
using UWP_Monograms.Infrastructure.Interfaces;

namespace UWP_Monograms.Infrastructure.Managers
{
	public class LevelManager : ILevelManager
	{
		public ILevelSelectionManager SelectionManager { get; }

		public int CurrentLevet { get; private set; }

		public LevelManager(ILevelSelectionManager levelSelectionManager)
		{
			SelectionManager = levelSelectionManager;
		}

		public Color[,] TryToSelectLevel(int number)
		{
			try
			{
				var level = SelectionManager.GetLevel(number);
				CurrentLevet = number;

				return level;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
	}
}
