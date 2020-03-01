using System;
using MonogramsLib.Interfaces;

namespace MonogramsLib.Models.Events
{
	public delegate void CellClickedEventHandler(object sender, CellClickedEventArgs e);

	public class CellClickedEventArgs : EventArgs
	{
		public ICell Cell { get; set; }
	}
}
