using Caliburn.Micro;

namespace UWP_Monograms.ViewModels
{
	public class ShellViewModel : Screen
	{
		private readonly INavigationService _navigationService;

		public ShellViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public void NavigateToStart()
		{
			_navigationService.For<MainViewModel>().Navigate();
		}
	}
}
