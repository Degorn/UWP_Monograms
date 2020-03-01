using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using UWP_Monograms.ViewModels;
using System.Threading.Tasks;

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

		private async void OnRestartTapped(object sender, TappedRoutedEventArgs e)
		{
			await ViewModel.ResetLevelAsync();
		}

		private void OnFirstImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			StartLevel(0);
		}

		private void OnSecondImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			StartLevel(1);
		}

		private async void StartLevel(int number)
		{
			await ViewModel.InitializeMonogramAsync(number);
		}
	}
}
