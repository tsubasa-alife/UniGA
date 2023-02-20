using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
    public class GAExecuter
    {
        // 同期評価用
        public GAExecuter(IFitness fitness, ISelection selection, ICrossover crossover)
        {

        }

        // 非同期評価用
        public GAExecuter(IAsyncFitness asyncFitness, ISelection selection, ICrossover crossover)
        {

        }

    }
}

