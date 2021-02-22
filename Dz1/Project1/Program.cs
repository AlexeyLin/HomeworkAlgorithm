using System;

namespace Project1
{
    class Program
    {
        public class TestCase
        {
            public int input { get; set; }
            public string expectation { get; set; }
        }

        static string IsPrimeNum (int n)
        {
            int d = 0;
            int i = 2;
            while (i<n)
            {
                if (n % i == 0) d++;
                i++;
            }
            if (d==0)
            {
                return "Простое";
            }
            else
            {
                return "Не простое";
            }
        }

        static void Main(string[] args)
        {
            var casesTest = new TestCase[]
            {
                new TestCase{input = 16, expectation = "Не простое" },
                new TestCase{input = 7, expectation = "Простое" },
                new TestCase{input = 23, expectation = "Простое" },
            };
            foreach (var TestCase in casesTest)
            {
                Console.WriteLine($"Входное значение: {TestCase.input}\n" +
                $"Ожидаемый результат: {TestCase.expectation}\n" +
                $"Результат работы функции: {IsPrimeNum(TestCase.input)}\n");
            }
            IsPrimeNum(4);
            Console.ReadKey();
        }
    }
}
