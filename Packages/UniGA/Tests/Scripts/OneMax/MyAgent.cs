using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniGA;

public class MyAgent : AgentBase
{
	private System.Random random = new System.Random();

	public MyAgent(int length) : base(length)
	{
		CreateGenes();
	}

	public override Gene GenerateGene(int index)
	{
		var geneValue = random.Next(0, 2);
		return new Gene(geneValue);
	}

	public override IAgent CreateNewAgent(int length)
	{
		return new MyAgent(length);
	}
}
