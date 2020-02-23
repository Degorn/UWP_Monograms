using System.Drawing;

namespace MonogramsLib.Models
{
	public class Cell
	{
		public bool CanBeOpened { get; set; }
		public bool Opened { get; set; }
		public Color ContentColor { get; set; }

		public Cell()
		{
			CanBeOpened = false;
		}

		public Cell(Color color)
		{
			ContentColor = color;
			CanBeOpened = true;
		}

		internal void Open()
		{
			Opened = true;
		}
	}
}
