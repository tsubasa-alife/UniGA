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

		var fitness = new MyFitness();

		var agent = new MyAgent(8);

		var population = new Population(50, agent);

		var ga = new GAExecuter(population, fitness, selection, crossover, 10);

		Debug.Log("遺伝アルゴリズム開始");

		ga.Start();

		Debug.Log("遺伝アルゴリズム終了");

	}
}
