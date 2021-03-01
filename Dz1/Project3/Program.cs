using System;

namespace Project3
{
    class Program
    {
        public class TestCase
        {
            public int input { get; set; }
            public int expectation { get; set; }
        }

        static int PhibonachiNumberRecur(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return PhibonachiNumberRecur(number - 1) + PhibonachiNumberRecur(number - 2);
            }
        }
        
        static int PhibonachiNumber(int number)
        {
            if (number < 0)
            {
                Console.WriteLine("Ошибка");
                
            }
            int[] phibonachi = new int[number+2];
            phibonachi[0] = 0;
            phibonachi[1] = 1;
            for(int i = 2; i<=number; i++)
            {
                phibonachi[i] = phibonachi[i - 1] + phibonachi[i - 2];
            }
            return phibonachi[number];
        }

        static void Main(string[] args)
        {

            var casesTest = new TestCase[]
            {
                new TestCase{input = 0, expectation = 0 },
                new TestCase{input = 7, expectation = 13 },
                new TestCase{input = 20, expectation = 6765 },
            };
            foreach(var TestCase in casesTest)
            {
                Console.WriteLine($"Входное значение: {TestCase.input}\n" +
                $"Ожидаемый результат: {TestCase.expectation}\n" +
                $"Результат работы функции с рекурсией: {PhibonachiNumberRecur(TestCase.input)}\n" +
                $"Результат работы функции без рекурсии:{PhibonachiNumber(TestCase.input)}");
            }
            Console.ReadKey();
        }
    }
}
