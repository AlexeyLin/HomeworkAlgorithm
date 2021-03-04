using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    public class NodeList : ILinkedList
    {
        Node startNode;
        Node lastNode;
        int count;

        public int GetCount()
        {
            return count;
        }

        public void AddNode(int value)
        {
            var newNode = new Node { Value = value };
            if (startNode == null)
            {
                startNode = newNode;

            }
            else if (lastNode == null)
            {
                lastNode = newNode;
                startNode.NextNode = lastNode;
                lastNode.PrevNode = startNode;
            }
            else
            {
                lastNode.NextNode = newNode;
                newNode.PrevNode = lastNode;
                lastNode = newNode;
            }
            count++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { Value = value };
            if (node.NextNode != null)
            {
                var next = node.NextNode;
                newNode.NextNode = next;
                next.PrevNode = newNode;
            }
            newNode.PrevNode = node;
            node.NextNode = newNode;
            if (newNode.NextNode == null)
                lastNode = newNode;
            count++;
        }

        public void RemoveNode(int index)
        {
            int cnt = 1;
            Node removeNode = startNode;
            while (cnt != index)
            {
                removeNode = removeNode.NextNode;
                cnt++;
            }
            RemoveNode(removeNode);
        }

        public void RemoveNode(Node node)
        {
            if (node.NextNode == null)
            {
                node.PrevNode.NextNode = null;
                lastNode = node.PrevNode;
            }
            else if (node.PrevNode == null)
            {
                node.NextNode.PrevNode = null;
                startNode = node.NextNode;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
            count--;
        }

        public Node FindNode(int searchValue)
        {
            var currentNodeStart = startNode;
            var currentNodeLast = lastNode;

            while (currentNodeStart != null || currentNodeLast != null)
            {
                if (currentNodeStart.Value == searchValue)
                    return currentNodeStart;
                if (currentNodeLast.Value == searchValue)
                    return currentNodeLast;

                currentNodeStart = currentNodeStart.NextNode;
                currentNodeLast = currentNodeLast.PrevNode;
            }

            return null; // если ничего не нашли, то null
        }

        public void DrowList()
        {
            Node drawNode = startNode;
            Console.Write(drawNode.Value);
            while(drawNode.NextNode != null)
            {
                drawNode = drawNode.NextNode;
                Console.Write($" {drawNode.Value}");
            }
            Console.WriteLine();
        }
    }
}
