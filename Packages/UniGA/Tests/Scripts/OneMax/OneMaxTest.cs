using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGA;

public class OneMaxTest : MonoBehaviour
{
	void Start()
	{
		Debug.Log("Hello UniGA. Let's solve OneMax-Problem !");

		var selection = new EliteSelection();

		var crossover = new UniformCrossover();

		var mutation = new UniformMutation();

		var fitness = new MyFitness();

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

		ga.Start();

		Debug.Log("遺伝アルゴリズム終了");

	}
}
