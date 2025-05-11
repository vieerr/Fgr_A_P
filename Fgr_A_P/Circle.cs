using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Circle : IFgr
    {
        public float Radius { get; set; }
        public float GetArea()
        {
            return (float)Math.PI * Radius * Radius;
        }
        public float GetPerimeter()
        {
            return 2 * (float)Math.PI * Radius;
        }
    }
}
