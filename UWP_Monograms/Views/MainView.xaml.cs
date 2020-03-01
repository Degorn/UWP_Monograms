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
			ViewModel.ResetLevel();
		}

		private void OnFirstImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			StartLevel(0);
		}

		private void OnSecondImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			StartLevel(1);
		}

		private void StartLevel(int number)
		{
			ViewModel.InitializeMonogram(number);
		}
	}
}
