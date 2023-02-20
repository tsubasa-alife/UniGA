using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public class UniformCrossover : CrossoverBase
	{
		private System.Random random = new System.Random();

		public UniformCrossover(float mixProbability) : base(2,2)
		{
			MixProbability = mixProbability;
		}

		public UniformCrossover() : this(0.5f)
		{

		}

		public float MixProbability { get; set; }

		protected override IList<IAgent> PerformCross(IList<IAgent> parentAgents)
		{
			var firstParent = parentAgents[0];
			var secondParent = parentAgents[1];
			var firstChild = firstParent.CreateNewAgent(firstParent.Length);
			var secondChild = secondParent.CreateNewAgent(secondParent.Length);

			for (int i = 0; i < firstParent.Length; i++)
			{
				float randValue = (float)random.NextDouble();

				if (randValue < MixProbability)
				{
					firstChild.ReplaceGene(i, firstParent.GetGene(i));
					secondChild.ReplaceGene(i, secondParent.GetGene(i));
				}
				else
				{
					firstChild.ReplaceGene(i, secondParent.GetGene(i));
					secondChild.ReplaceGene(i, firstParent.GetGene(i));
				}

			}

			return new List<IAgent> { firstChild, secondChild };
		}

	}

}

