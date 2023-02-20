using System.Collections.Generic;

namespace UniGA
{
	public interface ISelection
	{
		IList<IAgent> SelectAgents(int number, Generation generation);
	}
}

