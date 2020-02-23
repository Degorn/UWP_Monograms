using MonogramsLib;
using MonogramsLib.Models;
using System.Drawing;
using System.Threading.Tasks;
using UWP_Monograms.Components;
using UWP_Monograms.Infrastructure.ImageManager;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using UWP_Monograms.Infrastructure.Extensions;
using Windows.UI;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UWP_Monograms.ViewModels;
using System.Linq;

namespace UWP_Monograms.Views
{
	public sealed partial class MainView : Page
	{
		public Monogram Monogram;

		private CellControl[,] _cells;
		private Point _startDragPoint, _endDragPoint;
		private bool _isDragging;

		public ObservableCollection<ConditionsPack> ColumnsConditions { get; set; } = new ObservableCollection<ConditionsPack>();
		public ObservableCollection<ConditionsPack> RowsConditions { get; set; } = new ObservableCollection<ConditionsPack>();

		public MainView()
		{
			this.InitializeComponent();

			InitializeMonogram();
		}

		private void InitializeMonogram()
		{
			Monogram = new Monogram();
			Monogram.CellOpened += OnMonogramCellOpened;

			InitField(@"Assets\Images\1.png");
		}

		private void InitField(string path)
		{
			var image = Task.Run(async () => await ImageManager.GetImage(path)).Result;

			Monogram.GenerateFrom(image);
			_cells = new CellControl[Monogram.Height, Monogram.Width];

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

		private void ResetField()
		{
			FieldGrid.Children.Clear();
		}

		private void OnMonogramCellOpened(Cell sender, Point point)
		{
			_cells[point.Y, point.X].Fill = sender.ContentColor.ToBrush();
		}

		private void DrawField()
		{
			for (int x = 0; x < Monogram.Width; x++)
			{
				for (int y = 0; y < Monogram.Height; y++)
				{
					var rect = CreateRectangle(x, y);

					FieldGrid.Children.Add(rect);
				}
			}
		}

		private CellControl CreateRectangle(int x, int y)
		{
			var rect = _cells[y, x] = new CellControl
			{
				X = x,
				Y = y,
				StrokeThickness = 2,
				Stroke = new SolidColorBrush(Colors.Black)
			};

			rect.PointerPressed += OnCellPointerPressed;
			rect.PointerReleased += OnCellPointerRelesed;
			rect.PointerMoved += OnCellPointerMoved;
			rect.PointerEntered += OnCellPointerEntered;
			rect.PointerExited += OnCellPointerExited;

			return rect;
		}

		private void OnCellPointerEntered(object sender, PointerRoutedEventArgs e)
		{
			if (!_isDragging)
			{
				var cell = (sender as CellControl);

				cell.Hovered = true;
			}
		}

		private void OnCellPointerExited(object sender, PointerRoutedEventArgs e)
		{
			if (!_isDragging)
			{
				var cell = (sender as CellControl);

				cell.Hovered = false;
			}
		}

		private void OnCellPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			var cell = (sender as CellControl);

			_startDragPoint = new Point(cell.X, cell.Y);

			_isDragging = true;
		}

		private void OnCellPointerRelesed(object sender, PointerRoutedEventArgs e)
		{
			var cell = (sender as CellControl);

			_endDragPoint = new Point(cell.X, cell.Y);

			Monogram.TryToOpenRange(_startDragPoint.X, _startDragPoint.Y, _endDragPoint.X, _endDragPoint.Y);

			_isDragging = false;

			DepaintCellsRange();

			cell.Hovered = true;
		}

		private void OnCellPointerMoved(object sender, PointerRoutedEventArgs e)
		{
			if (_isDragging)
			{
				DepaintCellsRange();

				var cell = (sender as CellControl);

				_endDragPoint = new Point(cell.X, cell.Y);

				PaintOverCellsRange();
			}
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
					_cells[y, x].Hovered = true;
				}
			}
		}

		private void DepaintCellsRange()
		{
			foreach (var cell in _cells)
			{
				cell.Hovered = false;
			}
		}

		private void OnRestartTapped(object sender, TappedRoutedEventArgs e)
		{
			ResetField();
			InitField(@"Assets\Images\2.png");
		}

		private void OnFirstImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			ResetField();
			InitField(@"Assets\Images\1.png");
		}

		private void OnSecondImageButtonTapped(object sender, TappedRoutedEventArgs e)
		{
			ResetField();
			InitField(@"Assets\Images\2.png");
		}
	}
}
