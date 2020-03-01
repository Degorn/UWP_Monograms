using Caliburn.Micro;
using MonogramsLib.Models;

namespace UWP_Monograms.ViewModels
{
	public class ConditionCellViewModel : Screen
	{
		public ConditionItem ConditionItem { get; set; }

		public bool IsDone => ConditionItem.IsDone;

		public void UpdateState()
		{
			NotifyOfPropertyChange(() => IsDone);
		}
	}
}
