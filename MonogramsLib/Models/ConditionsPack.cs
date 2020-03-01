using MonogramsLib.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace MonogramsLib.Models
{
	public class ConditionsPack : IEnumerable
	{
		public IEnumerable<ConditionItem> Conditions { get; set; }

		public ConditionsPack(IEnumerable<ConditionItem> conditions)
		{
			Conditions = conditions;
		}

		public IEnumerator GetEnumerator()
		{
			return Conditions.GetEnumerator();
		}
	}
}
