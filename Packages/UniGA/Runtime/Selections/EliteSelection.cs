using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniGA
{
	/// <summary>
	/// エリート選択を行うクラス
	/// </summary>
	public class EliteSelection : ISelection
	{

		private List<IAgent> _previousGenerationAgents;

		public IList<IAgent> SelectAgents(int number, Generation generation)
		{
			_previousGenerationAgents = new List<IAgent>();

			_previousGenerationAgents.AddRange(generation.Agents);

			var selected = _previousGenerationAgents.OrderByDescending(a => a.Fitness).Take(number).ToList();

			return selected;
		}

	}

}

