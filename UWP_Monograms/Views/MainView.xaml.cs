using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using UWP_Monograms.ViewModels;

namespace UWP_Monograms.Views
{
	public sealed partial class MainView : Page
	{
		public  MainViewModel ViewModel { get; set; }

		public MainView()
		{
			this.InitializeComponent();

			DataContextChanged += (s, e) =>
			{
				ViewModel = DataContext as MainViewModel;
			};
		}

		private void OnRestartTapped(object sender, TappedRoutedEventArgs e)
		{
			ViewModel.ResetField();
			ViewModel.InitializeMonogram(@"Assets\Images\2.png");
		}

		private void OnFirstImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			ViewModel.ResetField();
			ViewModel.InitializeMonogram(@"Assets\Images\1.png");
		}

		private void OnSecondImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			ViewModel.ResetField();
			ViewModel.InitializeMonogram(@"Assets\Images\2.png");
		}
	}
}
