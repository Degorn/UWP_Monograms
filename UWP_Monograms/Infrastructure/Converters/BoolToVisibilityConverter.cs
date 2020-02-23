using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UWP_Monograms.Infrastructure.Converters
{
	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var boolValue = value as bool?;

			if (boolValue == null)
			{
				throw new ArgumentException();
			}

			return boolValue == true ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
