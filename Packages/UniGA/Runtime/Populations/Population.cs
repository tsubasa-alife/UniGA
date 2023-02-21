using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
	/// <summary>
	/// Agentの世代が複数集まった母集団のクラス
	/// </summary>
	public class Population : IPopulation
	{

		public Population(int size, IAgent agent)
		{
			Size = size;
			BaseAgent = agent;
			Generations = new List<Generation>();
		}

		public int GenerationsNumber { get; set; }

		public IList<Generation> Generations { get; set; }

		public Generation CurrentGeneration { get; set; }

		public int Size { get; set; }

		public IAgent BestAgent { get; protected set; }

		public IAgent BaseAgent { get; set; }

		// 初期世代を生成する
		public void CreateInitialGeneration()
		{
			Generations = new List<Generation>();
			GenerationsNumber = 0;

			var agents = new List<IAgent>();

			for (int i = 0; i < Size; i++)
			{
				var agent = BaseAgent.CreateNewAgent(BaseAgent.Length);

				agents.Add(agent);
			}

			CreateNewGeneration(agents);
		}

		// 新しい世代を生成する
		public void CreateNewGeneration(IList<IAgent> agents)
		{
			CurrentGeneration = new Generation(GenerationsNumber, agents);
			GenerationsNumber++;
			Generations.Add(CurrentGeneration);
		}

		public void EndCurrentGeneration()
		{
			CurrentGeneration.End(Size);

			if (BestAgent == null || BestAgent.CompareTo(CurrentGeneration.BestAgent) != 0)
			{
				BestAgent = CurrentGeneration.BestAgent;
			}
		}

	}
}


