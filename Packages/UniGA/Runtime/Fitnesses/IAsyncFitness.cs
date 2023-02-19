using Cysharp.Threading.Tasks;

namespace UniGA
{
	public interface IAsyncFitness
	{
		UniTask<double> Evaluate(IChromosome chromosome);
	}
}

