using System;
using System.ComponentModel;
using System.Linq;

namespace UniGA
{
	public class UniformMutation : MutationBase
	{
		private int[] _mutableGenesIndexes;

		private readonly bool _allGenesMutable;

		public UniformMutation(params int[] mutableGenesIndexes)
		{
			_mutableGenesIndexes = mutableGenesIndexes;
		}

		public UniformMutation(bool allGenesMutable)
		{
			_allGenesMutable = allGenesMutable;
		}

		public UniformMutation() : this(false)
		{

		}


		protected override void PerformMutate(IAgent agent, float probability)
		{
			var genesLength = agent.Length;

			if (_mutableGenesIndexes == null || _mutableGenesIndexes.Length == 0)
			{
				if (_allGenesMutable)
				{
                    _mutableGenesIndexes = Enumerable.Range(0, genesLength).ToArray();
                }
                else
                {
                    _mutableGenesIndexes = RandomizationProvider.Current.GetInts(1, 0, genesLength);
                }
            }

			for (int i = 0; i < _mutableGenesIndexes.Length; i++)
			{
				var geneIndex = _mutableGenesIndexes[i];

				if (geneIndex >= genesLength)
				{
					throw new Exception();
				}

				if (RandomizationProvider.Current.GetDouble() <= probability)
				{
					agent.ReplaceGene(geneIndex, agent.GenerateGene(geneIndex));
				}
			}
			
		}
	}
}

