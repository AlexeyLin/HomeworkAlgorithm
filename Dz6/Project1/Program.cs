using System;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void BFS(Node startNode)
        {
            Console.WriteLine("Создаем очередь и помещаем туда начало графа.");
            var queueGraph = new Queue<Node>();
            queueGraph.Enqueue(startNode);
            startNode.Visited = true;
            while (queueGraph.Count != 0)
            {
                var nextItem = queueGraph.Dequeue();
                Console.WriteLine($"Берем из очереди. Его значение {nextItem.Value}");
                if (nextItem.Nodes.Count != 0)
                {
                    for (int i = 0; i < nextItem.Nodes.Count; i++)
                    {
                        if (!nextItem.Nodes[i].Visited)
                        {
                            Console.WriteLine($"Элемент имеет не посещенную вершину со значением {nextItem.Nodes[i].Value}. Помещаем её в очередь.");
                            queueGraph.Enqueue(nextItem.Nodes[i]);
                            nextItem.Nodes[i].Visited = true;
                        }
                    }
                }
                else
                    Console.WriteLine($"Элемент не имеет вершин для посещения.");
            }
            Console.WriteLine($"Завершение обхода графа");
        }

        static void DFS(Node startNode)
        {
            Console.WriteLine("Создаем стек и помещаем туда начало дерева.");
            var stackGraph = new Stack<Node>();
            stackGraph.Push(startNode);
            startNode.Visited = true;
            while (stackGraph.Count != 0)
            {
                var nextItem = stackGraph.Pop();
                Console.WriteLine($"Берем не посещенный элемент из стека. Его значение {nextItem.Value}");
                if (nextItem.Nodes.Count != 0)
                {
                    for (int i = 0; i < nextItem.Nodes.Count; i++)
                    {
                        if (nextItem.Nodes[i].Visited == false)
                        {
                            Console.WriteLine($"Элемент имеет не посещенную вершину со значением {nextItem.Nodes[i].Value}. Помещаем её в стек.");
                            stackGraph.Push(nextItem.Nodes[i]);
                            nextItem.Nodes[i].Visited = true;
                        }
                    }
                }
                else
                    Console.WriteLine($"Элемент не имеет вершин для посещения.");
            }
            Console.WriteLine($"Завершение обхода графа");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("На входе задаем граф c вершинами 1 5 6 7 8 11 и связями между ними.");


            var NodeA = new Node()
            {
                Value = 1,
                Nodes = new List<Node>()
            };

            var NodeB = new Node()
            {
                Value = 5,
                Nodes = new List<Node>()
            };
            var NodeC = new Node()
            {
                Value = 6,
                Nodes = new List<Node>()
            };

            var NodeD = new Node()
            {
                Value = 7,
                Nodes = new List<Node>()
            };

            var NodeE = new Node()
            {
                Value = 9,
                Nodes = new List<Node>()
            };
            var NodeF = new Node()
            {
                Value = 11,
                Nodes = new List<Node>()
            };
            NodeA.Nodes.Add(NodeB);
            NodeA.Nodes.Add(NodeC);

            NodeB.Nodes.Add(NodeA);
            NodeB.Nodes.Add(NodeE);
            NodeB.Nodes.Add(NodeD);

            NodeC.Nodes.Add(NodeA);
            NodeC.Nodes.Add(NodeF);

            NodeD.Nodes.Add(NodeB);
            NodeD.Nodes.Add(NodeE);

            NodeE.Nodes.Add(NodeB);
            NodeE.Nodes.Add(NodeD);

            NodeF.Nodes.Add(NodeC);

            Node startNode = NodeA;

            List<Node> arrayNodes = new List<Node>();
            arrayNodes.Add(NodeA);
            arrayNodes.Add(NodeB);
            arrayNodes.Add(NodeC);
            arrayNodes.Add(NodeD);
            arrayNodes.Add(NodeE);
            arrayNodes.Add(NodeF);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Выполним проход по графу используя алгоритм ВFS.");
            Console.WriteLine("Элементы должны обходиться в данной последовательности: 1 5 6 9 7 11 ");
            Console.WriteLine("Результат обхода метода:");
            BFS(startNode);
            Console.WriteLine();
            Console.WriteLine("Обнуляем теги посещаемости вершин графа");

            foreach(Node node in arrayNodes)
            {
                node.Visited = false;
            }

            Console.WriteLine("Выполним проход по графу используя алгоритм DFS.");
            Console.WriteLine("Элементы должны обходиться в данной последовательности: 1 6 11 5 7 9");
            Console.WriteLine("Результат обхода метода.");
            DFS(startNode);
        }

    }
}
