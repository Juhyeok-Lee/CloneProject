using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem0720
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // 문제1. 별찍기.
            Console.WriteLine("값을 입력하세요.");
            int a = int.Parse(Console.ReadLine());      // 입력값.
            string star = "*";                          // 출력할 문자열.

            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("{0}", star);
                star += "*";                            // 반복할 때마다 문자열의 길이를 늘림.
            }

            // 문제2. 별찍기2.
            Console.WriteLine("값을 입력하세요.");
            a = int.Parse(Console.ReadLine());          // 입력값.           
            star = "*";                                 // 출력할 문자열.
            star = star.PadLeft(5);                     // 우측 정렬한 뒤 빈 칸을 공백으로 채움.
            for (int i = 0; i < a; i++)
            {
                Console.WriteLine("{0}", star);         
                star +="*";                             // 문자열의 길이를 늘림.
                star = star.Trim();                     // 공백문자 제거.
                star = star.PadLeft(5);                 // 우측 정렬.
            }

            // 문제3. 더하기 문제.
            Console.WriteLine("값을 입력하세요.");
            a = int.Parse(Console.ReadLine());          // 입력값.
            int tmp;                                    // 이전 값을 저장하는 변수.
            int num = a;                                // 게산할 값.
            int count = 0;                              // 사이클의 길이. 0으로 초기화함.
            do
            {
                count++;                                // 사이클이 반복될 때마다 count를 1씩 증가.
                tmp = num;                              // 임시 변수에 계산 이전 값을 저장.
                num = (int)(num / 10) + num % 10;       // 10의 자리 숫자와 1의 자리 숫자를 더함.
                num = (tmp % 10) * 10 + num % 10;       // 초기값의 1의 자리 숫자와 계산값의 1의 자리 숫자를 이어 붙임.
            } while (num != a);                         // 계산값이 입력값과 같아질 때까지 반복.
            Console.WriteLine(count);                   // 사이클이 반복된 숫자를 출력.
           
        }
    }
}
