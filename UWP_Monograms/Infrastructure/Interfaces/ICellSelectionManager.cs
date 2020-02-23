using UWP_Monograms.Infrastructure.Events;
using UWP_Monograms.ViewModels;

namespace UWP_Monograms.Infrastructure.Interfaces
{
	public interface ICellSelectionManager
	{
		event SendRangeEventArgs SendRange;

		void SetCells(CellViewModel[,] cellsArray);
	}
}
