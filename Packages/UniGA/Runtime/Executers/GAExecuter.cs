using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace UniGA
{
	public class GAExecuter
	{
		public const float DefaultCrossoverProbability = 0.75f;
		public const float DefaultMutationProbability = 0.1f;

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

			CrossoverProbability = DefaultCrossoverProbability;
			MutationProbability = DefaultMutationProbability;
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

            CrossoverProbability = DefaultCrossoverProbability;
            MutationProbability = DefaultMutationProbability;
        }

		// GA開始前に実行するイベント
		public event EventHandler BeforeGAStart;

		// 現世代Agentの適合度評価を行う前に実行するイベント 
		public event EventHandler BeforeEvaluation;

		// 次世代を生成する前に実行するイベント
		public event EventHandler BeforeEvolution;

		public IPopulation Population { get; private set; }

		public IFitness Fitness { get; private set; }

		public IAsyncFitness AsyncFitness { get; private set; }

		public ISelection Selection { get; set; }

		public ICrossover Crossover { get; set; }

		public float CrossoverProbability { get; set; }

		public IMutation Mutation { get; set; }

		public float MutationProbability { get; set; }

		public IReinsertion Reinsertion { get; set; }

		public int EndAge { get; set; }

		public IAgent BestAgent
		{
			get
			{
				return Population.BestAgent;
			}
		}

		public int GenerationsNumber
		{
			get
			{
				return Population.GenerationsNumber;
			}
		}

		// 遺伝アルゴリズムによる進化を開始する（同期）
		public void Start()
		{
			if (Fitness == null)
			{
				throw new Exception("Fitness is null");
			}

			var handler = BeforeGAStart;
			handler?.Invoke(this, EventArgs.Empty);

			Population.CreateInitialGeneration();

			for (int age = 0; age < EndAge; age++)
			{
				handler = BeforeEvaluation;
				handler?.Invoke(this, EventArgs.Empty);

				EvaluateFitness();
				Population.EndCurrentGeneration();

				handler = BeforeEvolution;
				handler?.Invoke(this, EventArgs.Empty);

				EvolveOneGeneration();
			}
			
		}

		// 遺伝アルゴリズムによる進化を開始する（非同期）
		public async UniTask StartAsync()
		{
			if (AsyncFitness == null)
			{
				throw new Exception("AsyncFitness is null");
			}

			var handler = BeforeGAStart;
			handler?.Invoke(this, EventArgs.Empty);

			Population.CreateInitialGeneration();

			for (int age = 0; age < EndAge; age++)
			{
                handler = BeforeEvaluation;
                handler?.Invoke(this, EventArgs.Empty);

                await AsyncEvaluateFitness();
				Population.EndCurrentGeneration();

                handler = BeforeEvolution;
                handler?.Invoke(this, EventArgs.Empty);

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
				Mutation.Mutate(offspring, MutationProbability);
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

