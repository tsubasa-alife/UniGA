using System.Collections;
using System.Collections.Generic;

namespace UniGA
{
	public interface IReinsertion
	{
		IList<IAgent> SelectAgents(IPopulation population, IList<IAgent> offspring, IList<IAgent> parents);
	}

}

