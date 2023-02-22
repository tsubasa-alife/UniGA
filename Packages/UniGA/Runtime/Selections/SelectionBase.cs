using System;
using System.Collections.Generic;
using System.Linq;

namespace UniGA
{
	public abstract class SelectionBase : ISelection
	{
		private readonly int _minNumberAgents;

		protected SelectionBase(int minNumberAgents)
		{
			_minNumberAgents = minNumberAgents;
		}

		public IList<IAgent> SelectAgents(int number, Generation generation)
		{
			return PerformSelectAgents(number, generation);
		}

		protected abstract IList<IAgent> PerformSelectAgents(int number, Generation generation);
	}
}

