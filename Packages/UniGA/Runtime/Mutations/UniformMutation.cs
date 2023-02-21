using System;
using System.ComponentModel;
using System.Linq;

namespace UniGA
{
	public class UniformMutation : MutateBase
	{
		private Random random = new Random();
		private int[] m_mutableGenesIndexes;

		private readonly bool m_allGenesMutable;

		public UniformMutation(params int[] mutableGenesIndexes)
		{
			m_mutableGenesIndexes = mutableGenesIndexes;
		}

		public UniformMutation(bool allGenesMutable)
		{
			m_allGenesMutable = allGenesMutable;
		}

		public UniformMutation() : this(false)
		{

		}


		protected override void PerformMutate(IAgent agent, float probability)
		{
			var genesLength = agent.Length;

			if (m_mutableGenesIndexes == null || m_mutableGenesIndexes.Length == 0)
			{
				if (m_allGenesMutable)
				{
                    m_mutableGenesIndexes = Enumerable.Range(0, genesLength).ToArray();
                }
                else
                {
                    m_mutableGenesIndexes = RandomizationProvider.Current.GetInts(1, 0, genesLength);
                }
            }

			for (int i = 0; i < m_mutableGenesIndexes.Length; i++)
			{
				var geneIndex = m_mutableGenesIndexes[i];

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

