using System;
using System.Collections.Generic;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тест создания и заполнения дерева данными:");
            Console.WriteLine("На вход подаются цифры: 10 4 6 1 13 7 11 12 14.");
            Console.WriteLine("Результат работы программы:");
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

            Console.WriteLine("Тест удаления узла дерева:");
            Console.WriteLine("Удаление 14 без листьев ");
            newTree.RemoveItem(14);
            Console.WriteLine("Результат работы программы:");
            newTree.PrintTree();
            Console.WriteLine();

            Console.WriteLine("Удаление 11 с 1 листом");
            newTree.RemoveItem(11);
            Console.WriteLine("Результат работы программы:");
            newTree.PrintTree();
            Console.WriteLine();

            Console.WriteLine("Удаление 4 с 2 листами");
            newTree.RemoveItem(4);
            Console.WriteLine("Результат работы программы:");
            newTree.PrintTree();
            Console.WriteLine();

            NodeInfo[] test = TreeHelper.GetTreeInLine(newTree);
            Console.Read();
        }
    }
}
