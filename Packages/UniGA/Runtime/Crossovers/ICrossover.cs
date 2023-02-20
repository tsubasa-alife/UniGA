using System.Collections.Generic;

namespace UniGA
{
	public interface ICrossover
	{
		// 交叉メソッド
		IList<IAgent> Cross(IList<IAgent> parentAgents);

	}
}
