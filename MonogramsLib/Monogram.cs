using MonogramsLib.Extensions;
using MonogramsLib.Interfaces;
using MonogramsLib.Managers;
using MonogramsLib.Models;
using MonogramsLib.Models.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace MonogramsLib
{
	public class Monogram
	{
		private const int
			MIN_WIDTH = 1,
			MIN_HEIGHT = 1;

		private const string EMPTY_COLOR_STRING = "ffffffff";

		private readonly ConditionManager _conditionManager;

		public Cell[,] Field { get; set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		public IEnumerable<ConditionsPack> RowsConditions { get; set; }
		public IEnumerable<ConditionsPack> ColumnsConditions { get; set; }

		#region Events

		public event CellClickedEventHandler CellOpened;
		public event CellClickedEventHandler WrongCellClicked;

		public event ConditionDoneEventHandler ConditionDone;

		public event EventHandler GameFinished;

		#endregion

		public Monogram()
		{
			_conditionManager = new ConditionManager();
		}

		public void GenerateRandom(int width, int height)
		{
			GenerateField(width, height);

			var random = new Random();

			ForEachCell(Field, (x, y) =>
			{
				if (random.Next(2) == 1)
				{
					CreateCell(x, y, Color.Black);
				}
				else
				{
					CreateEmptyCell(x, y);
				}
			});

			CalculateConditions();
		}

		public void GenerateFrom(Color[,] colorMatrix)
		{
			GenerateField(colorMatrix.GetWidth(), colorMatrix.GetHeight());

			ForEachCell(colorMatrix, (x, y) =>
			{
				if (colorMatrix.GetCell(x, y) == Color.Transparent ||
					colorMatrix.GetCell(x, y).Name == EMPTY_COLOR_STRING)
				{
					CreateEmptyCell(x, y);
				}
				else
				{
					CreateCell(x, y, colorMatrix.GetCell(x, y));
				}
			});

			CalculateConditions();
		}

		public void TryToOpenRange(int startX, int startY, int endX, int endY)
		{
			int startXCorrected = startX,
				startYCorrected = startY,
				endXCorrected = endX,
				endYCorrected = endY;

			if (startX > endX)
			{
				startXCorrected = endX;
				endXCorrected = startX;
			}

			if (startY > endY)
			{
				startYCorrected = endY;
				endYCorrected = startY;
			}

			var limitation = (startXCorrected, startYCorrected, endXCorrected, endYCorrected);

			ForEachCell(Field, (x, y) =>
			{
				TryToOpenCell(x, y);
			}, limitation);
		}

		private void GenerateField(int width, int height)
		{
			Width = width;
			Height = height;

			Field = new Cell[
				height < MIN_HEIGHT ? MIN_HEIGHT : height,
				width < MIN_WIDTH ? MIN_WIDTH : width];

			RowsConditions = new Collection<ConditionsPack>();
			ColumnsConditions = new Collection<ConditionsPack>();
		}

		private void ForEachCell<T>(T[,] matrix, Action<int, int> action, (int startX, int startY, int endX, int endY)? limitation = null)
		{
			var height = matrix.GetHeight();
			var width = matrix.GetWidth();

			var startX = limitation?.startX ?? 0;
			var endX = limitation?.endX ?? width - 1;

			var startY = limitation?.startY ?? 0;
			var endY = limitation?.endY ?? height - 1;

			for (var x = startX; x <= endX; x++)
			{
				for (var y = startY; y <= endY; y++)
				{
					action.Invoke(x, y);
				}
			}
		}

		private void TryToOpenCell(int x, int y)
		{
			var cell = Field.GetCell(x, y);

			if (!cell.CanBeOpened)
			{
				WrongCellClicked?.Invoke(this, new CellClickedEventArgs
				{
					Cell = cell
				});
			}

			cell.Open();
			CellOpened?.Invoke(this, new CellClickedEventArgs
			{
				Cell = cell
			});

			UpdateConditions(x, y);
			CheckGameStatus();
		}

		private void UpdateConditions(int columnIndex, int rowIndex)
		{
			UpdateLineConditions(ColumnsConditions, columnIndex);
			UpdateLineConditions(RowsConditions, rowIndex);
		}

		private void UpdateLineConditions(IEnumerable<ConditionsPack> rowsConditions, int lineIndex)
		{
			var pack = rowsConditions.ElementAt(lineIndex).Conditions.Where(c => !c.IsDone);

			foreach (var item in pack)
			{
				if (item.Cells == null || item.Cells.Any(c => !c.Opened))
				{
					continue;
				}

				item.Complete();
				ConditionDone?.Invoke(this, new ConditionDoneEventArgs
				{
					Condition = item,
				});
			}
		}

		private void CheckGameStatus()
		{
			if (CheckIfGameFinished())
			{
				GameFinished?.Invoke(this, EventArgs.Empty);
			}
		}

		private bool CheckIfGameFinished()
		{
			foreach (var item in Field)
			{
				if (!item.Opened)
				{
					return false;
				}
			}

			return true;
		}

		private void CreateEmptyCell(int x, int y)
		{
			Field[y, x] = new Cell();
		}

		private void CreateCell(int x, int y, Color color)
		{
			Field[y, x] = new Cell(color);
		}

		private void CalculateConditions()
		{
			RowsConditions = _conditionManager.CreateRowsConditions(Field);
			ColumnsConditions = _conditionManager.CreateColumnsConditions(Field);
		}
	}
}
