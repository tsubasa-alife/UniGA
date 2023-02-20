using System;

namespace UniGA
{
    public interface IAgent
    {
        // Agentが持つ遺伝子の個数
        int Length { get; set; }

        // Agentの適合度
        double Fitness { get; set; }

        // 新規Agentを作成する
        IAgent CreateNewAgent(int length);

        // 遺伝子を生成する
        Gene GenerateGene();

        // 遺伝子配列を生成する
        void CreateGenes();

        // 遺伝子を取得する
        Gene GetGene(int index);

        // 遺伝子配列を取得する
        Gene[] GetGenes();

    }
}
