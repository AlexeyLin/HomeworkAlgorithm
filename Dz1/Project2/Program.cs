using System;

namespace Project2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // Сложность операции O(1)
            for (int i = 0; i < inputArray.Length; i++) // Сложность цикла O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // Сложность цикла O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // Сложность цикла O(N), так как сложностью операций внутри цикла можно пренебречь
                    {
                        int y = 0; // Сложность операции O(1)

                        if (j != 0) // Сложность операции O(1)
                        {
                            y = k / j; 
                        }

                        sum += inputArray[i] + i + k + j + y; // Сложность операции O(1)
                    }
                }
            }

            return sum; // Сложность операции O(1)

            // Итоговая сложность функции O(N*N*N) 
        }
    }
}
