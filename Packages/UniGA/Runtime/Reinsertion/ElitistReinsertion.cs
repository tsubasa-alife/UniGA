using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniGA
{
	public class ElitistReinsertion : ReinsertionBase
	{
		protected override IList<IAgent> PerformSelectAgents(IPopulation population, IList<IAgent> offspring, IList<IAgent> parents)
		{
			var diff = population.Size - offspring.Count;

			if(diff > 0)
			{
				var bestParents = parents.OrderByDescending(p => p.Fitness).Take(diff).ToList();

				for (int i = 0; i < bestParents.Count; i++)
				{
					offspring.Add(bestParents[i]);
				}
			}

			return offspring;
		}
	}

}

