using System.Collections.Generic;
using System.Linq;

namespace UniGA
{
	public class ReverseSequenceMutation : SequenceMutationBase
	{
		public ReverseSequenceMutation()
		{
			
		}
		
		protected override IEnumerable<T> MutateOnSequence<T>(IEnumerable<T> sequence)
		{
			return sequence.Reverse();
		}
	}
}