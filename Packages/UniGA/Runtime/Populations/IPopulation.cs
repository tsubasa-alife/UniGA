using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	public interface IPopulation
	{ 
		IList<Generation> Generations { get; }

		Generation CurrentGeneration { get; }

		int Size { get; set; }

		int GenerationsNumber { get; set; }

		void CreateInitialGeneration();

		void CreateNewGeneration(IList<IAgent> agents);
	}
}


