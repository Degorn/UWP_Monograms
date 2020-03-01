using System.Drawing;
using MonogramsLib.Interfaces;

namespace MonogramsLib.Models
{
	public class Cell : ICell
	{
		private readonly Color _contentColor;

		public bool CanBeOpened { get; set; }
		public bool Opened { get; set; }
		public Color CurrentColor { get; set; }

		public Cell()
		{
			CanBeOpened = false;
		}

		public Cell (Color color)
		{
			_contentColor = color;
			CanBeOpened = true;
		}

		public void Open()
		{
			Opened = true;
			CurrentColor = _contentColor;
		}

		public bool Equals(ICell other)
		{
			return CanBeOpened.Equals(other.CanBeOpened);
		}
	}
}
