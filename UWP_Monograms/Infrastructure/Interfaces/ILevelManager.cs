using System.Drawing;

namespace UWP_Monograms.Infrastructure.Interfaces
{
	public interface ILevelManager
	{
		ILevelSelectionManager SelectionManager { get; }

		int CurrentLevet { get; }

		Color[,] TryToSelectLevel(int number);
	}
}
