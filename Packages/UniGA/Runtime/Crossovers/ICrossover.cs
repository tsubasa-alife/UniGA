using System.Collections.Generic;

namespace UniGA
{
	public interface ICrossover
	{ 
		int ParentsNumber { get; }

		int ChildrenNumber { get; }

		int MinAgentLength { get; }

		// 交叉メソッド
		IList<IAgent> Cross(IList<IAgent> parentAgents);

	}
}
