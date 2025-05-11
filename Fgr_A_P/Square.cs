using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fgr_A_P
{
    internal class Square: IFgr
    {
        public float Side { get; set; }
        public float GetArea()
        {
            return Side * Side;
        }
        public float GetPerimeter()
        {
            return 4 * Side;
        }
    }
}
