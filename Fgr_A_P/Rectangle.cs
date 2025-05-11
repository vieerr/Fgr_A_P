using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Rectangle: IFgr
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public float GetArea()
        {
            return Length * Width;
        }
        public float GetPerimeter()
        {
            return 2 * (Length + Width);
        }
    }
}
