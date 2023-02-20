using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
    public class GAExecuter
    {
        // 同期評価用
        public GAExecuter(IPopulation population, IFitness fitness, ISelection selection)
        {
            Population = population;
            Fitness = fitness;
            Selection = selection;
        }

        // 非同期評価用
        public GAExecuter(IPopulation population, IAsyncFitness asyncFitness, ISelection selection, ICrossover crossover)
        {
            Population = population;
            AsyncFitness = asyncFitness;
            Selection = selection;
        }

        public IFitness Fitness { get; set; }

        public IAsyncFitness AsyncFitness { get; set; }

        public IPopulation Population { get; set; }

        public ISelection Selection { get; set; }

        // 遺伝アルゴリズムによる進化を開始する
        public void Start()
        {

        }

    }
}

