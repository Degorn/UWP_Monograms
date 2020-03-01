using System;
using System.Drawing;

namespace MonogramsLib.Interfaces
{
	public interface ICell : IEquatable<ICell>
	{
		bool CanBeOpened { get; set; }
		bool Opened { get; set; }
		Color CurrentColor { get; set; }
	}
}
