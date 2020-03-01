using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace UWP_Monograms.ViewModels
{
	public class ConditionPackViewModel : Screen
	{
		public ObservableCollection<ConditionCellViewModel> Conditions { get; set; }
	}
}
