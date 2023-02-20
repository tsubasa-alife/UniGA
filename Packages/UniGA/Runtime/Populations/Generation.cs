using System.Collections;
using System.Collections.Generic;

namespace UniGA
{
	public class Generation
	{
		public Generation(int number, IList<IAgent> agents)
		{
			Agents = agents;
			Number = number;
		}

		// 世代の中にあるAgents
		public IList<IAgent> Agents { get; internal set; }

		// 世代の番号
		public int Number { get; internal set; }

	}

}

