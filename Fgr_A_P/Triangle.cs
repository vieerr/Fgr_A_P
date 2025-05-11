using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Triangle: IFgr
    {
        public float Base { get; set; }
        public float Height { get; set; }
        public float Side1 { get; set; }
        public float Side2 { get; set; }
        public float Side3 { get; set; }

        public float GetArea()
        {
            return (Base * Height) / 2;
        }
        public float GetPerimeter()
        {
            return Side1 + Side2 + Side3;
        }

    }
}
