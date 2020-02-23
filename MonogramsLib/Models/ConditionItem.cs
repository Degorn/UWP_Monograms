using MonogramsLib.Interfaces;

namespace MonogramsLib.Models
{
	public class ConditionItem : IConditionItem
	{
		public int Value { get; set; }

		public bool IsDone { get; set; }

		public ConditionItem()
		{
			Value = default;
		}

		public ConditionItem(int value)
		{
			Value = value;
		}
	}
}
