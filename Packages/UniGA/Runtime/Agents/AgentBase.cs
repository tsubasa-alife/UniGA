using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public abstract class AgentBase : IAgent
	{
		private Gene[] _genes;
		private int _length;

		public AgentBase(int length)
		{
			_length = length;
			_genes = new Gene[length];
		}

		public int Length
		{
			get
			{
				return _length;
			}
		}
		public double? Fitness { get; set; }

		public abstract Gene GenerateGene(int geneIndex);

		public void CreateGene(int index)
		{
			ReplaceGene(index, GenerateGene(index));
		}

		public void CreateGenes()
		{
			for (int i = 0; i < Length; i++)
			{
				ReplaceGene(i, GenerateGene(i));
			}
		}

		public abstract IAgent CreateNewAgent(int length);

		public Gene GetGene(int index)
		{
			return _genes[index];
		}

		public Gene[] GetGenes()
		{
			return _genes;
		}

		public void ReplaceGene(int index, Gene gene)
		{
			_genes[index] = gene;
			Fitness = null;
		}

		public void ReplaceGenes(int startIndex, Gene[] genes)
		{
			if (genes.Length > 0)
			{
				if (startIndex < 0 || startIndex >= _length)
				{
					
				}
				
				Array.Copy(genes, 0, _genes, startIndex, Math.Min(genes.Length, _length - startIndex));

				Fitness = null;
			}
		}
		
		public IAgent Clone()
		{
			var clone = CreateNewAgent(_length);
			clone.ReplaceGenes(0, GetGenes());
			clone.Fitness = Fitness;

			return clone;
		}

		public new string ToString()
		{
			string stringGenes = "";
			
			foreach (var gene in _genes)
			{
				var geneValue = gene.Value;
				stringGenes += geneValue + " ";
			}
			
			return stringGenes;
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

