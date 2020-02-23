using UWP_Monograms.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace UWP_Monograms.Views
{
	public sealed partial class ShellView : Page
	{
		public ShellViewModel ViewModel { get; set; }

		public ShellView()
		{
			this.InitializeComponent();

			DataContextChanged += (s, e) =>
			{
				ViewModel = DataContext as ShellViewModel;
			};
		}

		private void Button_Tapped(object sender, TappedRoutedEventArgs e)
		{
			ViewModel.NavigateToStart();
		}
	}
}
