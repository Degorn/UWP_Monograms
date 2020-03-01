using MonogramsLib.Models;
using UWP_Monograms.ViewModels;
using Windows.UI.Xaml.Controls;

namespace UWP_Monograms.Components
{
	public sealed partial class ConditionCellControl : UserControl
	{
		public ConditionCellViewModel ViewModel { get; set; }

		public ConditionCellControl()
		{
			this.InitializeComponent();
		}
	}
}
