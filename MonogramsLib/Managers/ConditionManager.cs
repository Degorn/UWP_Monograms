using MonogramsLib.Extensions;
using MonogramsLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace MonogramsLib.Managers
{
	internal class ConditionManager
	{
		private const string NOT_OPENABLE_CELL_CHAR = "0";
		private const string OPENABLE_CELL_CHAR = "1";
		private const string REGEX_BAND_SEPARATION_PATTERN = "1+";

		internal ICollection<ConditionsPack> CreateRowsConditions(Cell[,] field)
		{
			return CreateCondition(field, GetRowString, field.GetHeight());
		}

		internal ICollection<ConditionsPack> CreateColumnsConditions(Cell[,] field)
		{
			return CreateCondition(field, GetColumnString, field.GetWidth());
		}

		private ICollection<ConditionsPack> CreateCondition(Cell[,] field, Func<Cell[,], int, string> getBandStringAction, int bandCount)
		{
			var result = new Collection<ConditionsPack>();

			for (int i = 0; i < bandCount; i++)
			{
				var matches = Regex
					.Matches(getBandStringAction(field, i), REGEX_BAND_SEPARATION_PATTERN)
					.Cast<Match>()
					.Select(x => new ConditionItem(x.ToString().Length));

				var conditions = matches.Count() == 0
					? new Collection<ConditionItem>() { new ConditionItem() }
					: matches;

				result.Add(new ConditionsPack(conditions));
			}

			return result;
		}

		private string GetRowString(Cell[,] field, int row)
		{
			return GetBandString(() => field.GetRow(row));
		}

		private string GetColumnString(Cell[,] field, int column)
		{
			return GetBandString(() => field.GetColumn(column));
		}

		private string GetBandString(Func<Cell[]> action)
		{
			return string.Join(string.Empty, action()
				.Select(x => x.CanBeOpened
					? OPENABLE_CELL_CHAR
					: NOT_OPENABLE_CELL_CHAR));
		}
	}
}
