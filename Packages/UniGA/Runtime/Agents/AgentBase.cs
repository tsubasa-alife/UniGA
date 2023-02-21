using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public abstract class AgentBase : IAgent
	{
		private Gene[] genes;

		public AgentBase(int length)
		{
			Length = length;
			genes = new Gene[length];
		}

		public int Length { get; set; }
		public double? Fitness { get; set; }

		public abstract Gene GenerateGene();

		public void CreateGenes()
		{
			for (int i = 0; i < Length; i++)
			{
				genes[i] = GenerateGene();
			}
		}

		public abstract IAgent CreateNewAgent(int length);

		public Gene GetGene(int index)
		{
			return genes[index];
		}

		public Gene[] GetGenes()
		{
			return genes;
		}

		public void ReplaceGene(int index, Gene gene)
		{
			genes[index] = gene;
			Fitness = null;
		}

		public int CompareTo(IAgent other)
		{
			if (other == null)
			{
				return -1;
			}

			var otherFitness = other.Fitness;

			if (Fitness == otherFitness)
			{
				return 0;
			}

			return Fitness > otherFitness ? 1 : -1;
		}

	}
}

