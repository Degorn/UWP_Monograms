using Windows.UI.Xaml.Media;
using SColor = System.Drawing.Color;
using WColor = Windows.UI.Color;

namespace UWP_Monograms.Infrastructure.Extensions
{
	public static class ColorExtension
	{
		public static SolidColorBrush ToBrush(this SColor color)
		{
			return new SolidColorBrush(WColor.FromArgb(color.A, color.R, color.G, color.B));
		}

		public static SColor ToSystemColor(this WColor color)
		{
			return SColor.FromArgb(color.A, color.R, color.G, color.B);
		}
	}
}
