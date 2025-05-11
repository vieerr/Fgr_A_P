using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Elipse : IFgr
    {
        public float SemiMajorAxis { get; set; }
        public float SemiMinorAxis { get; set; }
        public float GetArea()
        {
            return (float)(Math.PI * SemiMajorAxis * SemiMinorAxis);
        }
        public float GetPerimeter()
        {
            return (float)(Math.PI * (3 * (SemiMajorAxis + SemiMinorAxis) - Math.Sqrt((3 * SemiMajorAxis + SemiMinorAxis) * (SemiMajorAxis + 3 * SemiMinorAxis))));
        }
    
    }
}
