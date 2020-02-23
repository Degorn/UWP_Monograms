using System;
using UWP_Monograms.ViewModels;

namespace UWP_Monograms.Infrastructure.Events
{
	public class CellActionEventArgs : EventArgs
	{
		public CellViewModel Cell { get; }

		public CellActionEventArgs(CellViewModel cell)
		{
			Cell = cell;
		}
	}
}
