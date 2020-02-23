using UWP_Monograms.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace UWP_Monograms.Components
{
	public sealed partial class CellControl : UserControl
	{
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

		public CellViewModel ViewModel { get; set; }

		public CellControl()
		{
			this.InitializeComponent();
		}

		private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
		{
			ViewModel.HoverIn();
		}

		private void OnPointerExited(object sender, PointerRoutedEventArgs e)
		{
			ViewModel.HoverOut();
		}

		private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			ViewModel.Pressed();
		}

		private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
		{
			ViewModel.Released();
		}

		private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
		{
			ViewModel.Moved();
		}
	}
}
