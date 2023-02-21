using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

		// 世代の中で最も適応度の高いAgent
		public IAgent BestAgent { get; internal set; }

		// 世代の番号
		public int Number { get; internal set; }

		public void End(int agentsNumber)
		{
			Agents = Agents.OrderByDescending(a => a.Fitness).ToList();

			if (Agents.Count > agentsNumber)
			{
				Agents = Agents.Take(agentsNumber).ToList();
			}

			BestAgent = Agents.First();
		}

	}

}

