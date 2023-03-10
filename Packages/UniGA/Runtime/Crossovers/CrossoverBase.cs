using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public abstract class CrossoverBase : ICrossover
	{
		protected CrossoverBase(int parentsNumber, int childrenNumber) : this(parentsNumber, childrenNumber, 2)
		{
			ParentsNumber = parentsNumber;
			ChildrenNumber = childrenNumber;
		}

		protected CrossoverBase(int parentsNumber, int childrenNumber, int minAgentLength)
		{
			ParentsNumber = parentsNumber;
			ChildrenNumber = childrenNumber;
			MinAgentLength = minAgentLength;
		}

		public int ParentsNumber { get; set; }

		public int ChildrenNumber { get; set; }

		public int MinAgentLength { get; set; }


		public IList<IAgent> Cross(IList<IAgent> parents)
		{
			var firstParent = parents[0];

			return PerformCross(parents);
		}

		protected abstract IList<IAgent> PerformCross(IList<IAgent> parents);
	}

}

