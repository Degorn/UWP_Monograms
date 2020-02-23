using MonogramsLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace UWP_Monograms.ViewModels
{
	public class ConditionsPackViewModel
	{
		public ConditionsPack Model { get; set; }

		public IEnumerable<ConditionItemViewModel> Items { get; private set; }

		public ConditionsPackViewModel()
		{
			//Items = Model.Conditions.Select(x => new ConditionItemViewModel(x));
		}
	}
}
