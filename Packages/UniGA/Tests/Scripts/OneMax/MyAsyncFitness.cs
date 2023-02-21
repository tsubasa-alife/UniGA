using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniGA;
using System;

public class MyAsyncFitness : IAsyncFitness
{
    public async UniTask<double> Evaluate(IAgent agent)
    {
        double fitness = 0;

        foreach (var gene in agent.GetGenes())
        {
            fitness += Convert.ToDouble(gene.Value);
        }

        await UniTask.Delay(3000);

        Debug.Log("適合度: " + fitness);
        return fitness;
    }
}
