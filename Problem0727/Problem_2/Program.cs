using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2번 문제. 연도가 주어졌을 때, 윤년이면 1, 아니면 0을 출력.
            // 윤년은 연도가 4의 배수이면서 100의 배수가 아닐 때,
            // 또는 400의 배수일 때이다.
            int year = 0;
            int leafYear = 0;

            while (true)
            {
                Console.WriteLine("연도를 입력하세요.");
                year = int.Parse(Console.ReadLine());
                if (year < 1 || year > 4000)
                {
                    Console.WriteLine("올바른 연도를 입력하세요.");
                }
                else
                {
                    break;
                }
            }

            if (year % 4 == 0 && year % 100 != 0) leafYear = 1;
            else if (year % 400 == 0) leafYear = 1;           

            Console.WriteLine(leafYear);
        }
    }
}