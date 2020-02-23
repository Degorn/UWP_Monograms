using MonogramsLib.Models;
using Windows.UI.Xaml.Controls;

namespace UWP_Monograms.Components.Conditions
{
	public sealed partial class ConditionPackControl : UserControl
	{
		public ConditionsPack Model { get; set; }

		public double ItemWidth { get; set; }

		public double ItemHeight { get; set; }

		public Orientation Orientation { get; set; }

		public ItemsPanelTemplate ItemsPanelTemplate => Orientation == Orientation.Vertical ? HorizontalStackPanel : VerticalStackPanel;

		public ConditionPackControl()
		{
			this.InitializeComponent();
		}
	}
}
