using Caliburn.Micro;
using MonogramsLib.Models;
using UWP_Monograms.Infrastructure.Events;
using UWP_Monograms.Infrastructure.Extensions;
using Windows.UI.Xaml.Media;

namespace UWP_Monograms.ViewModels
{
	public class CellViewModel : Screen
	{
		private bool _isHovered;

		public Cell Cell { get; set; }

		public int X { get; set; }

		public int Y { get; set; }

		public bool IsHovered
		{
			get => _isHovered;
			set
			{
				_isHovered = value;
				NotifyOfPropertyChange(() => IsHovered);
			}
		}

		public Brush Color => Cell.CurrentColor.ToBrush();

		public delegate void CellActionEventHandler(object sender, CellActionEventArgs e);
		public event CellActionEventHandler OnHoverIn;
		public event CellActionEventHandler OnHoverOut;
		public event CellActionEventHandler OnPressed;
		public event CellActionEventHandler OnReleased;
		public event CellActionEventHandler OnMoved;

		public void HoverIn()
		{
			OnHoverIn?.Invoke(this, new CellActionEventArgs(this));
		}

		public void HoverOut()
		{
			OnHoverOut?.Invoke(this, new CellActionEventArgs(this));
		}

		public void Pressed()
		{
			OnPressed?.Invoke(this, new CellActionEventArgs(this));
		}

		public void Released()
		{
			OnReleased?.Invoke(this, new CellActionEventArgs(this));
		}

		public void Moved()
		{
			OnMoved?.Invoke(this, new CellActionEventArgs(this));
		}

		public void UpdateColor()
		{
			NotifyOfPropertyChange(() => Color);
		}
	}
}
