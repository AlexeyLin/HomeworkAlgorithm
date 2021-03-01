using System;

namespace Project2
{
    class Program
    {
        // Так как на занятие проспойлерили решение данной задачи O(logn), пытался разобраться сам.
        //  Пришел к выводу что если мы проходим поочередно массив, то O(n). При бинарном поиске мы при каждой итерции 
        //  сокращаем количества проходов в двое, в результате т.е. получаем n/2/2/2/2 и так пока не найдем.
        // n разложится на  2 в какой то степени. 
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] array = { 1, 3, 4, 6, 8 };
            Console.WriteLine(BinarySearch(array, 6));
        }
    }
}
