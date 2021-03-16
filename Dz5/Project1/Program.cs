using System;
using System.Collections.Generic;

namespace Project2
{
    class Program
    {
        public static void BFS (BinaryTree newTree)
        {
            Console.WriteLine("Создаем очередь и помещаем туда начало дерева.");
            var queueTree = new Queue<TreeNode>();
            queueTree.Enqueue(newTree.GetRoot());
            while (queueTree.Count != 0)
            {
                var nextItem = queueTree.Dequeue();
                Console.WriteLine($"Берем элемент из очереди. Его значение {nextItem.Value}");
                if (nextItem.LeftChild != null)
                {
                    Console.WriteLine($"Элемент имеет левый лист. Помещаем его в очередь.");
                    queueTree.Enqueue(nextItem.LeftChild);
                }
                else
                    Console.WriteLine($"Элемент не имеет левого листа.");
                if (nextItem.RightChild != null)
                {
                    Console.WriteLine($"Элемент имеет правый лист. Помещаем его в очередь.");
                    queueTree.Enqueue(nextItem.RightChild);
                }
                else
                    Console.WriteLine($"Элемент не имеет правого листа.");
            }
            Console.WriteLine($"Завершение обхода дерева");
        }

        public static void DFS(BinaryTree newTree)
        {
            Console.WriteLine("Создаем стек и помещаем туда начало дерева.");
            var stackTree = new Stack<TreeNode>();
            stackTree.Push(newTree.GetRoot());
            while (stackTree.Count != 0)
            {
                var nextItem = stackTree.Pop();
                Console.WriteLine($"Берем элемент из стека. Его значение {nextItem.Value}");
                if (nextItem.RightChild != null)
                {
                    Console.WriteLine($"Элемент имеет правый лист. Помещаем его в стек.");
                    stackTree.Push(nextItem.RightChild);
                }
                else
                    Console.WriteLine($"Элемент не имеет правого листа.");
                if (nextItem.LeftChild != null)
                {
                    Console.WriteLine($"Элемент имеет левый лист. Помещаем его в стек.");
                    stackTree.Push(nextItem.LeftChild);
                }
                else
                    Console.WriteLine($"Элемент не имеет левого листа.");
            }
            Console.WriteLine($"Завершение обхода дерева");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("На входе имеем дерево вида:");
            var newTree = new BinaryTree();
            newTree.AddItem(10);
            newTree.AddItem(4);
            newTree.AddItem(6);
            newTree.AddItem(1);
            newTree.AddItem(13);
            newTree.AddItem(7);
            newTree.AddItem(11);
            newTree.AddItem(12);
            newTree.AddItem(14);
            newTree.PrintTree();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Выполним проход по дереву используя метод ВFS.");
            Console.WriteLine("Элементы должны обходиться в данной последовательности: 10 4 13 1 6 11 14 7 12");
            Console.WriteLine("Результат обхода метода.");
            BFS(newTree);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Выполним проход по дереву используя метод DFS.");
            Console.WriteLine("Элементы должны обходиться в данной последовательности: 10 4 1 6 7 13 11 12 14");
            Console.WriteLine("Результат обхода метода.");
            DFS(newTree);
        }
    }
}
