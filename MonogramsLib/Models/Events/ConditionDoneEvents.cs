using System;

namespace MonogramsLib.Models.Events
{
	public delegate void ConditionDoneEventHandler(object sender, ConditionDoneEventArgs e);

	public class ConditionDoneEventArgs : EventArgs
	{
		public ConditionItem Condition { get; set; }
	}
}
