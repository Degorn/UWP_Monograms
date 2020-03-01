using MonogramsLib.Interfaces;

namespace MonogramsLib.Models
{
	public class ConditionItem
	{
		public int Value { get; set; }

		public bool IsDone { get; set; }

		public ICell[] Cells { get; set; }

		public ConditionItem()
		{
			Value = default;
		}

		public ConditionItem(int value, ICell[] cells)
		{
			Value = value;
			Cells = cells;
		}

		public void Complete()
		{
			IsDone = true;
		}
	}
}
