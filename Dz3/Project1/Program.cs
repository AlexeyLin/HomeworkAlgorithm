using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class PointClass
    {
        public float X;
        public float Y;
    }

    public struct PointStruct
    {
        public float X;
        public float Y;
    }

    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }

    public class BechmarkClass
    {
        public static PointClass[] arrayClassPointA = new PointClass[100];
        public static PointClass[] arrayClassPointB = new PointClass[100];
        public static PointStruct[] arrayStructPointA = new PointStruct[100];
        public static PointStruct[] arrayStructPointB = new PointStruct[100];
        public static PointStructDouble[] arrayStructPointDoubleA = new PointStructDouble[100];
        public static PointStructDouble[] arrayStructPointDoubleB = new PointStructDouble[100];
        private Random rnd = new Random();

        public float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public float PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            float x = (float)(pointOne.X - pointTwo.X);
            float y = (float)(pointOne.Y - pointTwo.Y);
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceShortStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        public IEnumerable<object[]> DataPointClass()
        {
            for (int i = 0; i < 100; i++)
            {
                arrayClassPointA[i] = new PointClass { X = rnd.Next(0, 100), Y = rnd.Next(0, 100) };
                arrayClassPointB[i] = new PointClass { X = rnd.Next(0, 100), Y = rnd.Next(0, 100) };
            }

            yield return new object[] { arrayClassPointA, arrayClassPointB};
        }

        public IEnumerable<object[]> DataPointStruct()
        {
            for (int i = 0; i < 100; i++)
            {
                arrayStructPointA[i] = new PointStruct { X = rnd.Next(0, 100), Y = rnd.Next(0, 100) };
                arrayStructPointB[i] = new PointStruct { X = rnd.Next(0, 100), Y = rnd.Next(0, 100) };
            }

            yield return new object[] { arrayStructPointA, arrayStructPointB };
        }

        public IEnumerable<object[]> DataPointStructDouble()
        {
            for (int i = 0; i < 100; i++)
            {
                arrayStructPointDoubleA[i] = new PointStructDouble { X = rnd.Next(0, 100), Y = rnd.Next(0, 100) };
                arrayStructPointDoubleB[i] = new PointStructDouble { X = rnd.Next(0, 100), Y = rnd.Next(0, 100) };
            }

            yield return new object[] { arrayStructPointDoubleA, arrayStructPointDoubleB };
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataPointClass))]
        public void PointDistanceClassFloat(PointClass[] arrayPointA, PointClass[] arrayPointB)
        {
            for (int i = 0; i < 100; i++)
            {
                PointDistanceClass(arrayPointA[i], arrayPointB[i]);
            }    
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataPointStruct))]
        public void PointDistanceStructFloat(PointStruct[] arrayPointA, PointStruct[] arrayPointB)
        {
            for (int i = 0; i < 100; i++)
            {
                PointDistanceStruct(arrayPointA[i], arrayPointB[i]);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataPointStructDouble))]
        public void PointDistanceStructDouble(PointStructDouble[] arrayPointA, PointStructDouble[] arrayPointB)
        {
            for (int i = 0; i < 100; i++)
            {
                PointDistanceStructDouble(arrayPointA[i], arrayPointB[i]);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(DataPointStruct))]
        public void PointDistanceShortStruct(PointStruct[] arrayPointA, PointStruct[] arrayPointB)
        {
            for (int i = 0; i < 100; i++)
            {
                PointDistanceStruct(arrayPointA[i], arrayPointB[i]);
            }
        }
    }
}
