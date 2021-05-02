using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace GeekBrainsAlgos
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = BechmarkClass.RandomString();
            BechmarkClass.FillArrayHashString();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class BechmarkClass
    {
        public static HashSet<string> testHash = new HashSet<string>();
        public static string[] testArray = new string[10000];
        public static Random randomChar; 
        
        public static string RandomString()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] stringChars = new char[3];
            Random random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(stringChars);
        }
        
        public static void FillArrayHashString()
        {
            string newString = new string("");
            for (int i = 0; i < testArray.Length; i++)
            {
                
                testArray[i] = newString;
                testHash.Add(newString);
            }
        }
        
        public bool SearchInArray(string searchValue)
        {
            for(int i =0; i< 10000; i++)
            {
                if (testArray[i] == searchValue)
                    return true;
            }
            return false;
        }

        [Benchmark]
        public void TestSearchInArrayTrue()
        {
            SearchInArray(testArray[9999]);
        }

        [Benchmark]
        public void TestSearchInHashsetTrue()
        {
            testHash.Contains(testArray[9999]);
        }
    }
}
