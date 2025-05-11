using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Trapezoid : IFgr
    {
        public float Base1 { get; set; }
        public float Base2 { get; set; }
        public float Height { get; set; }
        public float Side1 { get; set; }
        public float Side2 { get; set; }
        public float GetArea()
        {
            return ((Base1 + Base2) * Height) / 2;
        }
        public float GetPerimeter()
        {
            return Base1 + Base2 + Side1 + Side2;
        }
    }
}
