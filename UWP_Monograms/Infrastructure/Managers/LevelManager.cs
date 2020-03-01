using System;
using System.Drawing;
using System.Threading.Tasks;
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

		public async Task<Color[,]> TryToSelectLevelAsync(int number)
		{
			try
			{
				var level = await SelectionManager.GetLevelAsync(number);
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
