using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UWP_Monograms.Components.Conditions
{
	public sealed partial class ConditionBandControl : UserControl
	{
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
			nameof(Orientation),
			typeof(Orientation),
			typeof(ConditionBandControl),
			new PropertyMetadata(default(Orientation)));

		public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
			nameof(ItemsSource),
			typeof(object),
			typeof(ConditionBandControl),
			new PropertyMetadata(default));

		public Orientation Orientation
		{
			get => (Orientation)GetValue(OrientationProperty);
			set => SetValue(OrientationProperty, value);
		}

		public object ItemsSource
		{
			get => GetValue(ItemsSourceProperty);
			set => SetValue(ItemsSourceProperty, value);
		}

		public Orientation OppositeOrientation => Orientation == Orientation.Horizontal ? Orientation.Vertical : Orientation.Horizontal;

		public ConditionBandControl()
		{
			this.InitializeComponent();
		}
	}
}
