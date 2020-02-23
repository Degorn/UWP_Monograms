using MonogramsLib.Interfaces;

namespace UWP_Monograms.ViewModels
{
	public class ConditionItemViewModel
	{
		public IConditionItem Model { get; set; }

		public double ItemWidth { get; set; }

		public double ItemHeight { get; set; }
	}
}
