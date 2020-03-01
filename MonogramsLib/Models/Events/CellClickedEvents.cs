using System;

namespace MonogramsLib.Models.Events
{
	public delegate void CellClickedEventHandler(object sender, CellClickedEventArgs e);

	public class CellClickedEventArgs : EventArgs
	{
		public Cell Cell { get; set; }
	}
}
