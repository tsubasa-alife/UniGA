using System.Collections.Generic;
using System.Linq;

namespace UniGA
{
	public abstract class SequenceMutationBase : MutationBase
	{
		protected override void PerformMutate(IAgent agent, float probability)
		{
			if (RandomizationProvider.Current.GetDouble() <= probability)
			{
				var indexes = RandomizationProvider.Current.GetUniqueInts(2, 0, agent.Length).OrderBy(i => i).ToArray();
				var firstIndex = indexes[0];
				var secondIndex = indexes[1];
				var sequenceLength = (secondIndex - firstIndex) + 1;

				var mutatedSequence =
					MutateOnSequence(agent.GetGenes().Skip(firstIndex).Take(sequenceLength)).ToArray();
				
				agent.ReplaceGenes(firstIndex, mutatedSequence);

			}
		}

		protected abstract IEnumerable<T> MutateOnSequence<T>(IEnumerable<T> sequence);
	}
}