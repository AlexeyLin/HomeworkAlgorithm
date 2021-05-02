using System;
using System.Collections.Generic;
using System.IO;

namespace Project2
{
    class Program
    {
        static void ExeternalSort(string initialDataPath)
        {
            int cnt = 1;
            using (StreamReader readData = new StreamReader(initialDataPath))
            {
                int number = Convert.ToInt32(readData.ReadLine());
                while (number != 0)
                {
                    List<int> array = new List<int>();
                    for (int i = 0; i < 100000; i++)
                    {
                        array.Add(number);
                        number = Convert.ToInt32(readData.ReadLine());
                        if (number == 0)
                        {
                            break;
                        }
                    }
                    array.Sort();
                    using (StreamWriter initialData = File.CreateText($"C:\\testfile\\{cnt}.txt"))
                    {
                        for (int i = 0; i < array.Count; i++)
                        {
                            initialData.WriteLine(Convert.ToString(array[i]));
                        }
                    }
                    cnt++;
                }
            }
            File.Delete(initialDataPath);
            int fileNum = 1;
            while (File.Exists($"C:\\testfile\\{fileNum}.txt"))
            {
                if (!File.Exists($"C:\\testfile\\{fileNum + 1}.txt"))
                {
                    File.Copy($"C:\\testfile\\{fileNum}.txt", initialDataPath);
                    File.Delete($"C:\\testfile\\{fileNum}.txt");
                }
                else
                {
                    using (StreamReader readDataOne = new StreamReader($"C:\\testfile\\{fileNum}.txt"))
                    {
                        int numOne = Convert.ToInt32(readDataOne.ReadLine());
                        using (StreamReader readDataTwo = new StreamReader($"C:\\testfile\\{fileNum + 1}.txt"))
                        {

                            int numTwo = Convert.ToInt32(readDataTwo.ReadLine());
                            using (StreamWriter initialDataCurrent = File.CreateText($"C:\\testfile\\{cnt}.txt"))
                            {
                                string numMin = "";
                                do
                                {

                                    if ((numOne <= numTwo && numOne != 0) || (numTwo == 0 && numOne != 0))
                                    {
                                        numMin = Convert.ToString(numOne);
                                        numOne = Convert.ToInt32(readDataOne.ReadLine());
                                    }
                                    else if ((numTwo != 0 && numOne > numTwo) || (numTwo != 0 && numOne == 0))
                                    {
                                        numMin = Convert.ToString(numTwo);
                                        numTwo = Convert.ToInt32(readDataTwo.ReadLine());
                                    }
                                    initialDataCurrent.WriteLine(numMin);
                                } while (numOne != 0 || numTwo != 0);
                            }
                            cnt++;
                        }
                    }
                    File.Delete($"C:\\testfile\\{fileNum}.txt");
                    File.Delete($"C:\\testfile\\{fileNum + 1}.txt");
                    fileNum += 2;
                }
            }
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
                for (int i = 0; i < 1000000; i++)
                {
                    initialData.WriteLine(rnd.Next(1, 1000));
                }
            }
            ExeternalSort(initialDataPath);
        }
    }
}
