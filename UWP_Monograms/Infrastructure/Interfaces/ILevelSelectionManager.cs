using System.Drawing;
using System.Threading.Tasks;

namespace UWP_Monograms.Infrastructure.Interfaces
{
	public interface ILevelSelectionManager
	{
		void AddLevel(string path);
		Task<Color[,]> GetLevelAsync(int number);
	}
}
