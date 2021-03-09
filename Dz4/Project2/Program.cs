using System;
using System.Collections.Generic;

namespace Project2
{
    class Program
    {
        static void Main(string[] args)
        {
            var newTree = new BinaryTree();
            newTree.AddItem(2);
            newTree.AddItem(4);
            newTree.AddItem(6);
            newTree.AddItem(1);

            TreeNode testFindNode = newTree.GetNodeByValue(4);

        }
    }
}
