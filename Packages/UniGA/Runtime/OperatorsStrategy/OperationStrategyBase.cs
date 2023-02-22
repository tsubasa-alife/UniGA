using System.Collections.Generic;
using System.Linq;

namespace UniGA
{
	public abstract class OperationStrategyBase : IOperatorsStrategy
	{
		public abstract IList<IAgent> Cross(IPopulation population, ICrossover crossover, float crossoverProbability, IList<IAgent> parents);

		public abstract void Mutate(IMutation mutation, float mutationProbability, IList<IAgent> agents);

		protected static IList<IAgent> SelectParentsAndCross(IPopulation population, ICrossover crossover, float crossoverProbability, IList<IAgent> parents, int firstParentIndex)
		{
			var selectedParents = parents.Skip(firstParentIndex).Take(crossover.ParentsNumber).ToList();

			if (selectedParents.Count == crossover.ParentsNumber && RandomizationProvider.Current.GetDouble() <= crossoverProbability)
			{
				return crossover.Cross(selectedParents);
			}

			return null;
		}
	}
}