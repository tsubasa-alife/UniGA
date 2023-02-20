using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public abstract class ReinsertionBase : IReinsertion
	{
		public IList<IAgent> SelectAgents(IPopulation population, IList<IAgent> offspring, IList<IAgent> parents)
		{
			return PerformSelectAgents(population, offspring, parents);
		}

		protected abstract IList<IAgent> PerformSelectAgents(IPopulation population, IList<IAgent> offspring, IList<IAgent> parents);
	}
}

