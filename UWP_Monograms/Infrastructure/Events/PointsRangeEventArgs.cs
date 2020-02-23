using System;
using System.Drawing;

namespace UWP_Monograms.Infrastructure.Events
{
	public delegate void SendRangeEventArgs(object sender, PointsRangeEventArgs e);

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
