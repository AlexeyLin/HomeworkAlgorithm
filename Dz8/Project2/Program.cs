using System;
using System.Collections.Generic;
using System.IO;

namespace Project2
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
                int index = array[i] * (numBucket - 1) / rangeNum;
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

        static void Main(string[] args)
        {
            //Создание папки для хранения файлов и файла с начальными данными
            Random rnd = new Random();
            string path = @"C:\testfile";
            DirectoryInfo di = Directory.CreateDirectory(path);
            string initialDataPath = @"C:\testfile\initialData.txt";
            using (StreamWriter initialData = File.CreateText(initialDataPath))
            {
                for(int i = 0;i<100; i++)
                {
                    initialData.WriteLine(rnd.Next(1, 1000));
                }
            }

            int cnt = 1;
            using (StreamReader readData = new StreamReader(initialDataPath))
            {
                string number = readData.ReadLine();
                while (number != null)
                {
                    using (StreamWriter initialData = File.CreateText($"C:\\testfile\\{cnt}.txt"))
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            initialData.WriteLine(number);
                            number = readData.ReadLine();                             
                        }
                        cnt++;
                    }
                }
            }

        }
    }
}
