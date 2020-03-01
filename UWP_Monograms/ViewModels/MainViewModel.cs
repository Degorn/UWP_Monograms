﻿using Caliburn.Micro;
using MonogramsLib;
using MonogramsLib.Models;
using MonogramsLib.Models.Events;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UWP_Monograms.Infrastructure.Events;
using UWP_Monograms.Infrastructure.Interfaces;

namespace UWP_Monograms.ViewModels
{
	public class MainViewModel : Screen
	{
		private readonly ICellSelectionManager _cellSelectionManager;
		private readonly ILevelSelectionManager _levelSelectionManager;

		private ObservableCollection<ConditionPackViewModel> _columnsConditions;
		private ObservableCollection<ConditionPackViewModel> _rowsConditions;
		private ObservableCollection<CellViewModel> _cells;

		public ObservableCollection<ConditionPackViewModel> ColumnsConditions
		{
			get => _columnsConditions;
			set
			{
				_columnsConditions = value;
				NotifyOfPropertyChange();
			}
		}

		public ObservableCollection<ConditionPackViewModel> RowsConditions
		{
			get => _rowsConditions;
			set
			{
				_rowsConditions = value;
				NotifyOfPropertyChange();
			}
		}

		public ObservableCollection<CellViewModel> Cells
		{
			get => _cells;
			set
			{
				_cells = value;
				NotifyOfPropertyChange();
			}
		}

		public Monogram Monogram { get; set; }

		public CellViewModel[,] CellsArray { get; set; }

		public MainViewModel(
			ICellSelectionManager cellSelectionManager,
			ILevelSelectionManager levelSelectionManager)
		{
			_cellSelectionManager = cellSelectionManager;
			_levelSelectionManager = levelSelectionManager;

			InitializeMonogram(0);
		}

		public void InitializeMonogram(int level)
		{
			Monogram = new Monogram();
			Monogram.CellOpened += OnMonogramCellOpened;
			Monogram.ConditionDone += OnConditionDone;

			InitializeField(level);

			_cellSelectionManager.SetCells(CellsArray);
			_cellSelectionManager.SendRange += CellSelectionManager_SendRange;
		}

		public void InitializeField(int levelIndex)
		{
			var level = _levelSelectionManager.GetLevel(levelIndex);

			Monogram.GenerateFrom(level);

			ColumnsConditions = new ObservableCollection<ConditionPackViewModel>(GetConditions(Monogram.ColumnsConditions));
			RowsConditions = new ObservableCollection<ConditionPackViewModel>(GetConditions(Monogram.RowsConditions));

			CreateCells();
		}

		private IEnumerable<ConditionPackViewModel> GetConditions(IEnumerable<ConditionsPack> conditionsPacks)
		{
			return conditionsPacks.Select(colunmCondition => new ConditionPackViewModel
			{
				Conditions = new ObservableCollection<ConditionCellViewModel>(colunmCondition.Conditions.Select(x => new ConditionCellViewModel()
				{
					ConditionItem = x
				}))
			});
		}

		public void TryToOpenRange(int x1, int y1, int x2, int y2)
		{
			Monogram.TryToOpenRange(x1, y1, x2, y2);
		}

		private void CreateCells()
		{
			CellsArray = new CellViewModel[Monogram.Height, Monogram.Width];
			Cells = new ObservableCollection<CellViewModel>();

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
			ColumnsConditions.Clear();
			RowsConditions.Clear();
		}

		private void CellSelectionManager_SendRange(object sender, PointsRangeEventArgs e)
		{
			Monogram.TryToOpenRange(e.StartPoint.X, e.StartPoint.Y, e.EndPoint.X, e.EndPoint.Y);
		}

		private void OnMonogramCellOpened(object sender, CellClickedEventArgs e)
		{
			Cells.FirstOrDefault(x => x.Cell == e.Cell).UpdateColor();
		}

		private void OnConditionDone(object sender, ConditionDoneEventArgs e)
		{
			RowsConditions.Concat(ColumnsConditions)
				.SelectMany(x => x.Conditions)
				.FirstOrDefault(x => x.ConditionItem == e.Condition)?.UpdateState();
		}
	}
}
