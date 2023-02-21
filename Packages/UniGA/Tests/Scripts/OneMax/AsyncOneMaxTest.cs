using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGA;

public class AsyncOneMaxTest : MonoBehaviour
{
	private async void Start()
	{
		Debug.Log("Hello UniGA. Let's solve OneMax-Problem !");

		var selection = new EliteSelection();

		var crossover = new UniformCrossover();

		var fitness = new MyAsyncFitness();

		var agent = new MyAgent(8);

		var population = new Population(50, agent);

		var ga = new GAExecuter(population, fitness, selection, crossover, 10);

		Debug.Log("遺伝アルゴリズム開始");

		await ga.StartAsync();

		Debug.Log("遺伝アルゴリズム終了");

	}
}
