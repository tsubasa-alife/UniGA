using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UniGA
{
	public class RouletteSelection : SelectionBase
	{
		public RouletteSelection() : base(2)
		{
		}

		protected override IList<IAgent> PerformSelectAgents(int number, Generation generation)
		{
			var agents = generation.Agents;
			var rouletteWheel = new List<double>();
			var rnd = RandomizationProvider.Current;
			
			CalculateCumulativePercentFitness(agents, rouletteWheel);

			return SelectFromWheel(number, agents, rouletteWheel, () => rnd.GetDouble());
		}

		protected static IList<IAgent> SelectFromWheel(int number, IList<IAgent> agents, IList<double> rouletteWheel, Func<double> getPointer)
		{
			var selected = new List<IAgent>();

			for (int i = 0; i < number; i++)
			{
				var pointer = getPointer();

				var agent = rouletteWheel.Select((value, index) => new { Value = value, Index = index })
					.FirstOrDefault(r => r.Value >= pointer);

				if (agent != null)
				{
					selected.Add(agents[agent.Index].Clone());
				}
			}

			return selected;
		}

		protected static void CalculateCumulativePercentFitness(IList<IAgent> agents, IList<double> rouletteWheel)
		{
			var sumFitness = agents.Sum(a => a.Fitness.Value);

			var cumulativePercent = 0.0;

			foreach (var a in agents)
			{
				var fitness = a.Fitness;
				if (fitness != null)
				{
					cumulativePercent += fitness.Value / sumFitness;
				}

				rouletteWheel.Add(cumulativePercent);
			}
		}
	}
}
