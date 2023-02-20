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

        private List<IAgent> previousGenerationAgents;

        public IList<IAgent> SelectAgents(int number, Generation generation)
        {
            previousGenerationAgents = new List<IAgent>();

            previousGenerationAgents.AddRange(generation.Agents);

            var selected = previousGenerationAgents.OrderByDescending(a => a.Fitness).Take(number).ToList();

            return selected;
        }

    }

}

