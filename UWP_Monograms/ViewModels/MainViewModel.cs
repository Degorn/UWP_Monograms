using Caliburn.Micro;
using MonogramsLib;
using MonogramsLib.Models;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using UWP_Monograms.Infrastructure.Events;
using UWP_Monograms.Infrastructure.Interfaces;
using UWP_Monograms.Infrastructure.Managers;

namespace UWP_Monograms.ViewModels
{
	public class MainViewModel : Screen
	{
		public Monogram Monogram;

		public CellViewModel[,] CellsArray;

		public ObservableCollection<ConditionsPack> ColumnsConditions { get; set; } = new ObservableCollection<ConditionsPack>();
		public ObservableCollection<ConditionsPack> RowsConditions { get; set; } = new ObservableCollection<ConditionsPack>();

		public ObservableCollection<CellViewModel> Cells { get; set; } = new ObservableCollection<CellViewModel>();

		public MainViewModel(ICellSelectionManager cellSelectionManager)
		{
			InitializeMonogram();

			cellSelectionManager.SetCells(CellsArray);
			cellSelectionManager.SendRange += CellSelectionManager_SendRange;
		}

		private void InitializeMonogram()
		{
			Monogram = new Monogram();
			Monogram.CellOpened += OnMonogramCellOpened;

			InitField(@"Assets\Images\1.png");
		}

		public void InitField(string path)
		{
			var image = Task.Run(async () => await ImageManager.GetImage(path)).Result;

			Monogram.GenerateFrom(image);
			CellsArray = new CellViewModel[Monogram.Height, Monogram.Width];

			ColumnsConditions.Clear();
			foreach (var item in Monogram.ColumnsConditions)
			{
				ColumnsConditions.Add(item);
			};
			RowsConditions.Clear();
			foreach (var item in Monogram.RowsConditions)
			{
				RowsConditions.Add(item);
			};

			DrawField();

		}

		public void TryToOpenRange(int x1, int y1, int x2, int y2)
		{
			Monogram.TryToOpenRange(x1, y1, x2, y2);
		}

		private void DrawField()
		{
			for (int x = 0; x < Monogram.Width; x++)
			{
				for (int y = 0; y < Monogram.Height; y++)
				{
					CellsArray[y, x] = new CellViewModel
					{
						Cell = Monogram.Field[y, x],
						X = x,
						Y = y,
					};
					Cells.Add(CellsArray[y, x]);
				}
			}
		}

		public void ResetField()
		{
			Cells.Clear();
		}

		private void CellSelectionManager_SendRange(object sender, PointsRangeEventArgs e)
		{
			Monogram.TryToOpenRange(e.StartPoint.X, e.StartPoint.Y, e.EndPoint.X, e.EndPoint.Y);
		}

		private void OnMonogramCellOpened(Cell sender, Point point)
		{
			Cells.FirstOrDefault(x => x.Cell == sender).UpdateColor();
		}
	}
}
