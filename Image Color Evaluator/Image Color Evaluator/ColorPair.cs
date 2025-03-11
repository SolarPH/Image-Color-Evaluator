using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Color_Evaluator
{
    internal class ColorPair : IComparable<ColorPair>
    {
        private Color objectColor;
        private int objectCounter;
        private int canvasSize = 1;

        internal ColorPair(Color objectColor)
        {
            this.objectColor = objectColor;
            objectCounter = 1; // Initialized color have default initialized value of 1
        }

        internal ColorPair(Color objectColor, int canvasSize)
        {
            this.objectColor= objectColor;
            objectCounter = 1;
            this.canvasSize = canvasSize;
        }

        internal Color ObjectColor { get { return objectColor; } }
        internal int ObjectCounter { get { return objectCounter;} }

        internal string HEXcolor { get { return ColorTranslator.ToHtml(objectColor); } }
        internal string HEXcolorARGB { get { return $"{objectColor.A:X2}{objectColor.R:X2}{objectColor.G:X2}{objectColor.B:X2}"; } }
        internal double ColorCoverage { get { return (Convert.ToDouble(objectCounter) / Convert.ToDouble(canvasSize)) * 100.00; } }


        // allows sorting using Sort() from IComparable
        public int CompareTo(ColorPair? other)
        {
            if (other==null) return 1;
            // return this.objectCounter.CompareTo(other.objectCounter);
            // Reverse so that it is descending instead of ascending
            return other.objectCounter.CompareTo(this.objectCounter);
        }

        internal void Increment()
        {
            objectCounter++;
        }
    }
}
