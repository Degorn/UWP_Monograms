using MonogramsLib.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace MonogramsLib.Models
{
	public class ConditionsPack : IEnumerable
	{
		public IEnumerable<IConditionItem> Conditions { get; set; }

		public ConditionsPack(IEnumerable<IConditionItem> conditions)
		{
			Conditions = conditions;
		}

		public IEnumerator GetEnumerator()
		{
			return Conditions.GetEnumerator();
		}
	}
}
