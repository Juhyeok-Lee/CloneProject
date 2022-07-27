using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {
        static char[,] SquareSierpinski(int size)
        {
            char[,] sqr;
            if (size == 3)
            {
                sqr = new char[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            sqr[i, j] = ' ';
                        }
                        else
                        {
                            sqr[i, j] = '*';
                        }
                    }
                }
                return sqr;
            }
            else
            {
                sqr = new char[size, size];
                char[,] sqr_1 = SquareSierpinski(size / 3);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i < size * 2 / 3 && i >= size * 1 / 3)
                        {
                            if (j < size * 2 / 3 && j >= size * 1 / 3)
                            {
                                sqr[i, j] = ' ';
                            }
                            else
                            {
                                sqr[i, j] = sqr_1[i % (size / 3), j % (size / 3)];
                            }
                        }
                        else
                        {
                            sqr[i, j] = sqr_1[i % (size / 3), j % (size / 3)];
                        }
                    }
                }
                return sqr;
            }


        }

        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("N의 값을 입력하세요. (N은 3의 거듭제곱)");
            N = int.Parse(Console.ReadLine());
            char[,] sierSqr = new char[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(SquareSierpinski(N)[i, j]);
                }
                Console.Write("\n");
            }

        }
    }
}