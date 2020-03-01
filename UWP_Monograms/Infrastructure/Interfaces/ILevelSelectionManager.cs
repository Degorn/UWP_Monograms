using System.Drawing;

namespace UWP_Monograms.Infrastructure.Interfaces
{
	public interface ILevelSelectionManager
	{
		void AddLevel(string path);
		Color[,] GetLevel(int number);
	}
}
