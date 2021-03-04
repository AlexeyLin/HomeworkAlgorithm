using System;

namespace Project1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //Тест создания списка методом добавления элементов
            NodeList newNodeList = new NodeList();
            newNodeList.AddNode(1);
            newNodeList.AddNode(2);
            newNodeList.AddNode(3);
            newNodeList.AddNode(4);
            newNodeList.AddNode(5);
            Console.WriteLine("Тест создания списка");
            Console.WriteLine("Должно быть : 1 2 3 4 5");
            Console.Write("Результат работы программы : "); 
            newNodeList.DrowList();

            //Тест счетчика кол-ва элемнетов в списке
            Console.WriteLine();
            Console.WriteLine("Тест счетчика списка");
            Console.WriteLine("Должно быть :  5");
            Console.Write("Результат работы программы : ");
            Console.WriteLine(newNodeList.GetCount());

            //Тест поиска элемента и добавления элемента за ним
            Console.WriteLine();
            Console.WriteLine("Тест поиска элемента и добавления элемента за ним");
            Console.WriteLine("Должно быть :  1 2 3 4 5 6");
            Console.Write("Результат работы программы : ");
            Node test = newNodeList.FindNode(5);
            newNodeList.AddNodeAfter(test, 6);
            newNodeList.DrowList();


            //Тест удаления элемента по индексу(который включает в себя метод удаления по ссылке)            
            Console.WriteLine();
            Console.WriteLine("Тест удаления элемента по индексу");
            Console.WriteLine("Должно быть :  2 3 4 5");
            Console.Write("Результат работы программы : ");
            newNodeList.RemoveNode(6);
            newNodeList.RemoveNode(1);
            newNodeList.DrowList();


            Console.ReadKey();
            

        }
    }
}
