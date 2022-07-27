using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1번 문제. N개의 숫자가 공백 없이 쓰여있다.
            // 이 숫자를 모두 합해서 출력하는 프로그램을 작성하시오.

            Console.WriteLine("숫자의 개수를 입력하세요.");
            int a = int.Parse(Console.ReadLine());
            int[] array = new int[a];
            int sum = 0;

            Console.WriteLine("숫자를 차례로 적어주세요.");
            string str = Console.ReadLine();
            for (int i = 0; i < a; ++i)
            {
                array[i] = int.Parse(str.Substring(i, 1));
            }

            for (int i = 0; i < a; ++i)
            {
                sum += array[i];
            }

            Console.WriteLine("숫자의 합은 " + sum + "입니다.");
        }
    }
}
