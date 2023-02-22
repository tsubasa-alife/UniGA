using System.Collections.Generic;

namespace UniGA
{
	public interface IOperatorsStrategy
	{
		IList<IAgent> Cross(IPopulation population, ICrossover crossover, float crossoverProbability, IList<IAgent> parents);

		void Mutate(IMutation mutation, float mutationProbability, IList<IAgent> agents);
	}
}