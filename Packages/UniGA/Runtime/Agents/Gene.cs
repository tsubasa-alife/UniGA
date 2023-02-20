using System.Collections;
using System.Collections.Generic;

namespace UniGA
{
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

