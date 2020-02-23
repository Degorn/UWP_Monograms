using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace UWP_Monograms.Components
{
	public sealed partial class CellControl : UserControl
	{
		private bool _hovered;

		public int X { get; set; }
		public int Y { get; set; }

		public Brush Fill
		{
			get => CellContent.Fill;
			set => CellContent.Fill = value;
		}

		public Brush Stroke
		{
			get => CellContent.Stroke;
			set => CellContent.Stroke = value;
		}

		public double StrokeThickness
		{
			get => CellContent.StrokeThickness;
			set => CellContent.StrokeThickness = value;
		}

		public bool Hovered
		{
			get => _hovered;
			set
			{
				_hovered = value;

				HoverBlock.Visibility = _hovered
					? Visibility.Visible
					: Visibility.Collapsed;
			}
		}

		public CellControl()
		{
			this.InitializeComponent();
		}
	}
}
