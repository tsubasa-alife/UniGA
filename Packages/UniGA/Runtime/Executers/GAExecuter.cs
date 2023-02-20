using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace UniGA
{
	public class GAExecuter
	{
		// 同期評価用
		public GAExecuter(IPopulation population, IFitness fitness, ISelection selection, int endAge)
		{
			Population = population;
			Fitness = fitness;
			Selection = selection;
			EndAge = endAge;
		}

		// 非同期評価用
		public GAExecuter(IPopulation population, IAsyncFitness asyncFitness, ISelection selection, ICrossover crossover)
		{
			Population = population;
			AsyncFitness = asyncFitness;
			Selection = selection;
		}

		public IFitness Fitness { get; set; }

		public IAsyncFitness AsyncFitness { get; set; }

		public IPopulation Population { get; set; }

		public ISelection Selection { get; set; }

		public IMutation Mutation { get; set; }

		public ICrossover Crossover { get; set; }

		public int EndAge { get; set; }

		// 遺伝アルゴリズムによる進化を開始する（同期）
		public void Start()
		{
            Population.CreateInitialGeneration();

            for (int age = 0; age < EndAge; age++)
			{
				Debug.Log("第" + age + "世代");
				EvaluateFitness();
			}
			
		}

		// Agentの適合度を評価する
		private void EvaluateFitness()
		{
			var agents = Population.CurrentGeneration.Agents;
			foreach (var agent in agents)
			{
                var a = agent as IAgent;

                a.Fitness = Fitness.Evaluate(a);
            }
			
		}

	}
}

