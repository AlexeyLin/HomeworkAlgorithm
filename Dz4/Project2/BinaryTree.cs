using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    public class BinaryTree : ITree
    {
        static TreeNode rootNode;

        public void AddItem(int value)
        {
            TreeNode newNode = null;
            if (rootNode == null)
            {
                rootNode = new TreeNode() { Value = value };
                return;
            }
            newNode = rootNode;
            while (newNode != null)
            {
                if (value > newNode.Value)
                {
                    if (newNode.RightChild != null)
                    {
                        newNode = newNode.RightChild;
                        continue;
                    }
                    else
                    {
                        newNode.RightChild = new TreeNode() { Value = value };
                        return;
                    }
                }
                else if (value < newNode.Value)
                {
                    if (newNode.LeftChild != null)
                    {
                        newNode = newNode.LeftChild;
                        continue;
                    }
                    else
                    {
                        newNode.LeftChild = new TreeNode() { Value = value };
                        return;
                    }
                }
            }
        }

        public TreeNode GetRoot()
        {
            return rootNode;
        }

        public void RemoveItem(int value)
        {
            
        }

        public TreeNode GetNodeByValue(int value)
        {
            TreeNode findTree = rootNode;
            while (findTree.Value != value)
            {
                if (value > findTree.Value)
                {
                    findTree = findTree.RightChild;
                    continue;
                }
                else if (value < findTree.Value)
                {
                    findTree = findTree.LeftChild;
                    continue;
                }
            }
            return findTree;
        }

        public void PrintTree()
        {
            return;
        }
    }
}
