using System.Collections.Generic;

namespace UniGA
{
	public class DefaultOperatorsStrategy : OperationStrategyBase
	{
		public override IList<IAgent> Cross(IPopulation population, ICrossover crossover, float crossoverProbability, IList<IAgent> parents)
		{
			var size = population.Size;
			var offspring = new List<IAgent>();

			for (int i = 0; i < size; i += crossover.ParentsNumber)
			{
				var children = SelectParentsAndCross(population, crossover, crossoverProbability, parents, i);
				if (children != null)
				{
					offspring.AddRange(children);
				}
				
			}

			return offspring;
		}

		public override void Mutate(IMutation mutation, float mutationProbability, IList<IAgent> agents)
		{
			foreach (var agent in agents)
			{
				mutation.Mutate(agent, mutationProbability);
			}
		}
	}
}