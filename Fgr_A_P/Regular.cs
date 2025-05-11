using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class RegularPoly: IFgr
    {
        public int NumberOfSides { get; set; }
        public float SideLength { get; set; }
        public float GetArea()
        {
            return (float)((NumberOfSides * SideLength * SideLength) / (4 * Math.Tan(Math.PI / NumberOfSides)));
        }
        public float GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }
    }
}
