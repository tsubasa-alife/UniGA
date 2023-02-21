using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGA;

public class AsyncOneMaxTest : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("Hello UniGA. Let's solve OneMax-Problem asynchronously !");

		var selection = new EliteSelection();

		var crossover = new UniformCrossover();

		var mutation = new UniformMutation();

		var fitness = new MyAsyncFitness();

		var agent = new MyAgent(8);

		var population = new Population(5, agent);

		var ga = new GAExecuter(population, fitness, selection, crossover, mutation, 10);

		ga.BeforeEvaluation += (sender, e) =>
		{
			Debug.Log($"第{ga.Population.GenerationsNumber}世代");
		};

		ga.BeforeEvolution += (sender, e) =>
		{
			Debug.Log($"現世代の最高適応度: {ga.BestAgent.Fitness}");
		};

		Debug.Log("遺伝アルゴリズム開始");

		await ga.StartAsync();

		Debug.Log("遺伝アルゴリズム終了");

	}
}
