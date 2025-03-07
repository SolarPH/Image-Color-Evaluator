using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Color_Evaluator
{
    internal class ColorAnalytics
    {
        private Color color;
        private int counter;

        internal ColorAnalytics(Color color)
        {
            this.color = color;
            counter = 1;
        }

        internal Color Color { get { return color; } }
        internal int Counter { get { return counter; } }

        internal void IncrementCounter()
        {
            counter+=1;
        }
    }
}
