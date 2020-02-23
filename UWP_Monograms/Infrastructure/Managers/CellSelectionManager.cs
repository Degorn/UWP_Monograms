using System.Drawing;
using UWP_Monograms.Infrastructure.Events;
using UWP_Monograms.ViewModels;

namespace UWP_Monograms.Infrastructure.Managers
{
	public class CellSelectionManager
	{
		private Point
			_startDragPoint,
			_endDragPoint;
		private bool _isDragging;

		public CellViewModel[,] Cells { get; set; }

		public delegate void SendRangeEventArgs(object sender, PointsRangeEventArgs e);
		public event SendRangeEventArgs SendRange;

		public CellSelectionManager(CellViewModel[,] cells)
		{
			Cells = cells;

			foreach (var cell in cells)
			{
				cell.OnHoverIn += Cell_OnHovered;
				cell.OnHoverOut += Cell_OnHoverOut;
				cell.OnPressed += Cell_OnPressed;
				cell.OnReleased += Cell_OnReleased;
				cell.OnMoved += Cell_OnMoved;
			}
		}

		private void Cell_OnHovered(object sender, CellActionEventArgs e)
		{
			if (_isDragging)
			{
				return;
			}
			
			e.Cell.IsHovered = true;
		}

		private void Cell_OnHoverOut(object sender, CellActionEventArgs e)
		{
			if (_isDragging)
			{
				return;
			}

			e.Cell.IsHovered = false;
		}

		private void Cell_OnPressed(object sender, CellActionEventArgs e)
		{
			_startDragPoint = new Point(e.Cell.X, e.Cell.Y);

			_isDragging = true;
		}

		private void Cell_OnReleased(object sender, CellActionEventArgs e)
		{
			_endDragPoint = new Point(e.Cell.X, e.Cell.Y);

			SendRange?.Invoke(this, new PointsRangeEventArgs(_startDragPoint, _endDragPoint));

			_isDragging = false;

			DepaintCellsRange();

			e.Cell.IsHovered = true;
		}

		private void Cell_OnMoved(object sender, CellActionEventArgs e)
		{
			if (!_isDragging)
			{
				return;
			}

			DepaintCellsRange();

			_endDragPoint = new Point(e.Cell.X, e.Cell.Y);

			PaintOverCellsRange();
		}

		private void PaintOverCellsRange()
		{
			int startXCorrected = _startDragPoint.X,
				startYCorrected = _startDragPoint.Y,
				endXCorrected = _endDragPoint.X,
				endYCorrected = _endDragPoint.Y;

			if (_startDragPoint.X > _endDragPoint.X)
			{
				startXCorrected = _endDragPoint.X;
				endXCorrected = _startDragPoint.X;
			}

			if (_startDragPoint.Y > _endDragPoint.Y)
			{
				startYCorrected = _endDragPoint.Y;
				endYCorrected = _startDragPoint.Y;
			}

			for (int x = startXCorrected; x <= endXCorrected; x++)
			{
				for (int y = startYCorrected; y <= endYCorrected; y++)
				{
					Cells[y, x].IsHovered = true;
				}
			}
		}

		private void DepaintCellsRange()
		{
			foreach (var cell in Cells)
			{
				cell.IsHovered = false;
			}
		}
	}
}
