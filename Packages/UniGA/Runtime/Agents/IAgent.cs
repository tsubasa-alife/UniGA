using System;

namespace UniGA
{
	public interface IAgent : IComparable<IAgent>
	{
		// Agentが持つ遺伝子の個数
		int Length { get; }

		// Agentの適合度
		double? Fitness { get; set; }

		// 新規Agentを作成する
		IAgent CreateNewAgent(int length);

		// 遺伝子を生成する
		Gene GenerateGene(int geneIndex);

		// 遺伝子配列を生成する
		void CreateGenes();

		// 遺伝子を取得する
		Gene GetGene(int index);

		// 遺伝子配列を取得する
		Gene[] GetGenes();

		IAgent Clone();

		// 遺伝子を置き換える
		void ReplaceGene(int index, Gene gene);

		void ReplaceGenes(int startIndex, Gene[] genes);

	}
}
