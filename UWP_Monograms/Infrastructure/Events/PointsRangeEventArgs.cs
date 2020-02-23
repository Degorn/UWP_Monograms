using System;
using System.Drawing;

namespace UWP_Monograms.Infrastructure.Events
{
	public class PointsRangeEventArgs : EventArgs
	{
		public Point StartPoint { get; }

		public Point EndPoint { get; }

		public PointsRangeEventArgs(Point startPoint, Point endPoint)
		{
			StartPoint = startPoint;
			EndPoint = endPoint;
		}
	}
}
