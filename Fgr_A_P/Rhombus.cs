using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Rhombus : IFgr
    {
        public float Diagonal1 { get; set; }
        public float Diagonal2 { get; set; }
        public float Side { get; set; }

        public float GetArea()
        {
            return (Diagonal1 * Diagonal2) / 2;
        }
        public float GetPerimeter()
        {
            return 4 * Side;
        }

    }
}
