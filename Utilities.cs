using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_2
{
    public static class Utilities
    {
        public static void Swap<T>(ref T left, ref T right)
        {
            T temp  = left;
            left = right;
            right = temp;

        }
    }
}
