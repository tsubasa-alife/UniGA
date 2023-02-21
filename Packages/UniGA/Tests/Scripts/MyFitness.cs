using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGA;

public class MyFitness : IFitness
{
	public double Evaluate(IAgent agent)
	{
		double fitness = 0;

		foreach (var gene in agent.GetGenes())
		{
			fitness += Convert.ToDouble(gene.Value);
		}

		//Debug.Log("適合度: " + fitness);
		return fitness;
	}
}
