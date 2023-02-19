namespace UniGA
{
	public interface IFitness
	{
		double Evaluate(IChromosome chromosome);
	}
}