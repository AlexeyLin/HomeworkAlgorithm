using System;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static int[] BucketSort(int[] array)
        {
            int cnt = 0;
            int minNumArray = array[0];
            int maxNumArray = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                minNumArray = Math.Min(minNumArray, array[i]);
                maxNumArray = Math.Max(maxNumArray, array[i]);
            }
            int rangeNum = maxNumArray - minNumArray;
            int numBucket = rangeNum / 20;
            List<int>[] arrayBucket = new List<int>[numBucket];
            for (int i = 0; i < arrayBucket.Length; i++)
                arrayBucket[i] = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                int index = array[i] * (numBucket-1) / rangeNum;
                arrayBucket[index].Add(array[i]);
            }
            for (int i = 0; i < arrayBucket.Length; i++)
            {
                arrayBucket[i].Sort();
                foreach (int num in arrayBucket[i])
                {
                    array[cnt] = num;
                    cnt++;
                }
            }
            return array;
        }
        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] array = new int [80];
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(1, 100);
            }
            Console.WriteLine("На вход подается массив:");
            PrintArray(array);
            array = BucketSort(array);
            Console.WriteLine("После сортировки получаем:");
            PrintArray(array);
        }
    }
}
