using MonogramsLib.Extensions;
using MonogramsLib.Interfaces;
using MonogramsLib.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MonogramsLib.Managers
{
	internal class ConditionManager
	{
		internal IEnumerable<ConditionsPack> CreateRowsConditions(ICell[,] field)
		{
			var result = new Collection<ConditionsPack>();

			foreach (var row in field.GetRows())
			{
				result.Add(CreateBandCondition(row));
			}

			return result;
		}

		internal IEnumerable<ConditionsPack> CreateColumnsConditions(ICell[,] field)
		{
			var result = new Collection<ConditionsPack>();

			foreach (var column in field.GetColumns())
			{
				result.Add(CreateBandCondition(column));
			}

			return result;
		}

		private ConditionsPack CreateBandCondition(ICell[] cells)
		{
			var pack = new Collection<ConditionItem>();

			for (int i = 0; i < cells.Length; i++)
			{
				var conditionCells = cells
					.Skip(i)
					.TakeWhile(x => x.CanBeOpened && x.Equals(cells[i]))
					.ToArray();

				var count = conditionCells.Count();

				i += count;

				if (count > 0)
				{
					pack.Add(new ConditionItem(count, conditionCells));
				}
			}

			if (pack.Count == 0)
			{
				pack.Add(new ConditionItem());
			}

			return new ConditionsPack(pack);
		}
	}
}
