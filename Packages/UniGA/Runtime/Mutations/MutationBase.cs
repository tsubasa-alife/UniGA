using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public abstract class MutationBase : IMutation
	{
		public void Mutate(IAgent agent, float probability)
		{
			PerformMutate(agent, probability);
		}

		protected abstract void PerformMutate(IAgent agent, float probability);
	}
}

