using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace UniGA
{
	public class GAExecuter
	{
		// 同期評価用
		public GAExecuter(IPopulation population, IFitness fitness, ISelection selection, ICrossover crossover, IMutation mutation, int endAge)
		{
			Population = population;
			Fitness = fitness;
			Selection = selection;
			Crossover = crossover;
			Mutation = mutation;
			Reinsertion = new ElitistReinsertion();
			EndAge = endAge;
		}

		// 非同期評価用
		public GAExecuter(IPopulation population, IAsyncFitness asyncFitness, ISelection selection, ICrossover crossover, IMutation mutation, int endAge)
		{
			Population = population;
			AsyncFitness = asyncFitness;
			Selection = selection;
			Crossover = crossover;
			Mutation = mutation;
			Reinsertion = new ElitistReinsertion();
			EndAge = endAge;
		}

		public IFitness Fitness { get; set; }

		public IAsyncFitness AsyncFitness { get; set; }

		public IPopulation Population { get; set; }

		public ISelection Selection { get; set; }

		public IMutation Mutation { get; set; }

		public ICrossover Crossover { get; set; }

		public IReinsertion Reinsertion { get; set; }

		public int EndAge { get; set; }

		public IAgent BestAgent
		{
			get
			{
				return Population.BestAgent;
			}
		}

		// 遺伝アルゴリズムによる進化を開始する（同期）
		public void Start()
		{
			Population.CreateInitialGeneration();

			for (int age = 0; age < EndAge; age++)
			{
				Debug.Log("第" + age + "世代");
				EvaluateFitness();
				Population.EndCurrentGeneration();
				Debug.Log("第" + age + "世代の最高適合度: " + BestAgent.Fitness);
				EvolveOneGeneration();
			}
			
		}

		// 遺伝アルゴリズムによる進化を開始する（非同期）
		public async UniTask StartAsync()
		{
			Population.CreateInitialGeneration();

			for (int age = 0; age < EndAge; age++)
			{
				Debug.Log("第" + age + "世代");
				await AsyncEvaluateFitness();
				Population.EndCurrentGeneration();
				Debug.Log("第" + age + "世代の最高適合度: " + BestAgent.Fitness);
				EvolveOneGeneration();
			}

		}

		// 現在の世代を進化させて新しい世代を生成する
		private void EvolveOneGeneration()
		{
			var parents = Selection.SelectAgents(Population.Size, Population.CurrentGeneration);
			var offsprings = Crossover.Cross(parents);
			foreach (var offspring in offsprings)
			{
				Mutation.Mutate(offspring, 0.05f);
			}
			var newGenerationAgents = Reinsertion.SelectAgents(Population, offsprings, parents);
			Population.CreateNewGeneration(newGenerationAgents);
		}

		// Agentの適合度を評価する（同期）
		private void EvaluateFitness()
		{
			var agents = Population.CurrentGeneration.Agents;
			foreach (var agent in agents)
			{
				var a = agent as IAgent;

				a.Fitness = Fitness.Evaluate(a);
			}
			
		}

		// Agentの適合度を評価する（非同期）
		private async UniTask AsyncEvaluateFitness()
		{
			var agents = Population.CurrentGeneration.Agents;
			foreach (var agent in agents)
			{
				var a = agent as IAgent;

				a.Fitness = await AsyncFitness.Evaluate(a);
			}
		}

	}
}

