using System.Drawing;
using System.Threading.Tasks;

namespace UWP_Monograms.Infrastructure.Interfaces
{
	public interface ILevelManager
	{
		ILevelSelectionManager SelectionManager { get; }

		int CurrentLevet { get; }

		Task<Color[,]> TryToSelectLevelAsync(int number);
	}
}
