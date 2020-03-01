using MonogramsLib.Models;
using Windows.UI.Xaml.Controls;

namespace UWP_Monograms.Components
{
	public sealed partial class ConditionCellControl : UserControl
	{
		public ConditionItem Model { get; set; }

		public ConditionCellControl()
		{
			this.InitializeComponent();
		}
	}
}
