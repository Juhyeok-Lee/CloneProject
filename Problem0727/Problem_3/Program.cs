using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {
        string SquareSierpinski(int size)
        {
            if (size == 3)
            {
                string str;
                str=str+ "*"*size;
                return str;
            }
            return SquareSierpinski(size / 3);
        }

        static void Main(string[] args)
        {
        }
    }
}
