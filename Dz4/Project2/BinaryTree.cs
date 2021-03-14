using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    public class BinaryTree : ITree
    {
        private TreeNode rootNode;
        


        public void AddItem(int value)
        {
            if (rootNode == null)
            {
                rootNode = new TreeNode() { Value = value };
                return;
            }
            TreeNode newNode = rootNode;
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
                else if (value <= newNode.Value)
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
            TreeNode delTreeNode = rootNode;
            TreeNode parentNode = new TreeNode();
            while (delTreeNode.Value != value)
            {
                if (value > delTreeNode.Value)
                {
                    parentNode = delTreeNode;
                    delTreeNode = delTreeNode.RightChild;
                    continue;
                }
                else if (value <= delTreeNode.Value)
                {
                    parentNode = delTreeNode;
                    delTreeNode = delTreeNode.LeftChild;
                    continue;
                }
            }
            if (delTreeNode.LeftChild == null && delTreeNode.RightChild == null)
            {
                if (parentNode.LeftChild == delTreeNode)
                    parentNode.LeftChild = null;
                else
                    parentNode.RightChild = null;
            }
            else if (delTreeNode.LeftChild == null || delTreeNode.RightChild == null)
            {
                if (delTreeNode.LeftChild == null)
                {
                    if (parentNode.LeftChild == delTreeNode)
                        parentNode.LeftChild = delTreeNode.RightChild;
                    else
                        parentNode.RightChild = delTreeNode.RightChild;
                }
                else
                {
                    if (parentNode.LeftChild == delTreeNode)
                        parentNode.LeftChild = delTreeNode.LeftChild;
                    else
                        parentNode.RightChild = delTreeNode.LeftChild;
                }
            }
            else
            {
                TreeNode current = delTreeNode;
                TreeNode replace = current;
                TreeNode parentReplace = parentNode;
                while (current != null)
                {
                    if (current.Value <= value)
                    {
                        parentReplace = parentNode;
                        replace = current;
                        parentNode = current;
                        current = current.LeftChild;
                    }
                    else
                    {
                        parentNode = current;
                        current = current.RightChild;
                    }
                }
                delTreeNode.Value = replace.Value;
                if (parentReplace.LeftChild == replace)
                    parentReplace.LeftChild = replace.RightChild;
                else
                    parentReplace.RightChild = replace.RightChild;
            }
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

        private int cnt;

        public void PrintTreenode(TreeNode node)
        {           
            Console.WriteLine(node.Value);
            if (node.LeftChild != null)
            {
                for (int i = 0; i < cnt; i++)
                {
                    Console.Write("      ");
                }
                Console.Write("|_____");
                cnt++;
                PrintTreenode(node.LeftChild);
                cnt--;
            }
            if (node.RightChild != null)
            {
                for (int i = 0; i < cnt; i++)
                {
                    Console.Write("      ");
                }
                Console.Write("|_____");
                cnt++;
                PrintTreenode(node.RightChild);
                cnt--;
            }
            return;
            
        }

        public void PrintTree()
        {
            PrintTreenode(rootNode);
        }
    }
}
