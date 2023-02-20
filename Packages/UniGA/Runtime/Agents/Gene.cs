using System.Collections;
using System.Collections.Generic;

namespace UniGA
{
	// 値が格納される遺伝子クラス
	public class Gene
	{
		private object geneValue;

		public object Value
		{
			get
			{
				return geneValue;
			}
		}

		public Gene(object value)
		{
			geneValue = value;
		}
	}
}

