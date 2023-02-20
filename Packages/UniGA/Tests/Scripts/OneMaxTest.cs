using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGA;

public class OneMaxTest : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("Hello UniGA. Let's solve OneMax-Problem !");
		var selection = new EliteSelection();

		var fitness = new MyFitness();

		var agent = new MyAgent(8);

		var population = new Population(5, agent);

		var ga = new GAExecuter(population, fitness, selection);
	}
}
