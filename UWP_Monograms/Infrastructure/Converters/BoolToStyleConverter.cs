using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UWP_Monograms.Infrastructure.Converters
{
	public class BoolToStyleConverter : IValueConverter
	{
		public Style Style { get; set; }

		public Style AlternativeStyle { get; set; }

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (!(value is bool))
			{
				throw new ArgumentException();
			}

			return ((bool)value) ? AlternativeStyle : Style;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
