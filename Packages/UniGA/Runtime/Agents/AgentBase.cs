using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniGA
{
    public abstract class AgentBase : IAgent
    {
        private Gene[] genes;

        public AgentBase(int length)
        {
            Length = length;
            genes = new Gene[length];
        }

        public int Length { get; set; }
        public double Fitness { get; set; }

        public abstract Gene GenerateGene();

        public void CreateGenes()
        {
            for (int i = 0; i < Length; i++)
            {
                genes[i] = GenerateGene();
            }

            Debug.Log("遺伝子配列を生成しました サイズ: " + Length);
        }

        public abstract IAgent CreateNewAgent(int length);

        public Gene GetGene(int index)
        {
            return genes[index];
        }

        public Gene[] GetGenes()
        {
            return genes;
        }

    }
}

