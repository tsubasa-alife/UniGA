using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public interface IMutation
	{
		void Mutate(IAgent agent, float probability);
	}
}