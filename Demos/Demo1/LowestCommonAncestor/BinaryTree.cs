using System;
using System.Collections.Generic;

namespace LowestCommonAncestor
{
    // This class represents a binary tree structure.

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;

        public BinaryTreeNode<T> Root
        {
            get { return this.root; }
        }

        // A constructor used to initialise a Binary Tree.

        public BinaryTree()
        {

        }

        // Constructors that construct the binary tree.

        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            BinaryTreeNode<T> leftChildNode = leftChild != null ? leftChild.root : null;
            BinaryTreeNode<T> rightChildNode = rightChild != null ? rightChild.root : null;
            this.root = new BinaryTreeNode<T>(value, leftChildNode, rightChildNode);
        }

        public BinaryTree(T value)
            : this(value, null, null)
        {

        }

        // With this method the user inputs random nodes to fill the binary tree structure.

        public void InputNodes(string[] nodes)
        {
            string value;
            List<string> tempNodes = new List<string>();

            for (int i = 0; i < nodes.Length; i++)
            {
                Console.Write("Enter node {0}: ", i + 1);
                value = Console.ReadLine();

                if (tempNodes.Contains(value))
                {
                    Console.WriteLine();
                    Console.WriteLine("There is another node with the same value!");
                    Console.WriteLine();
                    i--;
                }
                else
                {
                    nodes[i] = value;
                    tempNodes.Add(value);
                }
            }
        }

        // Methods that traverse and print the binary tree with the Preorder algorithm.

        private void printPreorder(BinaryTreeNode<T> root, int interval)
        {
            if (root == null)
            {
                return;
            }

            Console.Write(new string(' ', 2 * interval));
            Console.WriteLine(root.Value);

            printPreorder(root.LeftChild, interval + 1);
            printPreorder(root.RightChild, interval + 1);
        }

        public void PrintPreorder()
        {
            int interval = 0;
            printPreorder(this.root, interval);
        }

        // This method traverses the binary tree and finds the node given by the user.

        public BinaryTreeNode<T> SearchNode(BinaryTreeNode<T> root, BinaryTreeNode<T> inputNode)
        {
            if (root == null)
            {
                return null;
            }
            else if (object.Equals(root.Value, inputNode.Value))
            {
                inputNode = root;
                return inputNode;
            }
            else
            {
                BinaryTreeNode<T> left = SearchNode(root.LeftChild, inputNode);

                if (left != null)
                {
                    return left;
                }

                BinaryTreeNode<T> right = SearchNode(root.RightChild, inputNode);

                if (right != null)
                {
                    return right;
                }

                return null;
            }
        }

        // The method where the lowest common ancestor algorithm is realized.

        public BinaryTreeNode<T> FindLowestCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode)
        {
            if (root == null)
            {
                return null;
            }

            if (root == firstNode || root == secondNode)
            {
                return root;
            }

            BinaryTreeNode<T> left = FindLowestCommonAncestor(root.LeftChild, firstNode, secondNode);
            BinaryTreeNode<T> right = FindLowestCommonAncestor(root.RightChild, firstNode, secondNode);

            if (left != null && right != null)
            {
                return root;
            }

            if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        // This method prints as an output the result if a lowest common ancestor is found.

        public void PrintLowestCommonAncestor(BinaryTreeNode<T> ancestor, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode)
        {
            Console.WriteLine();

            // If the user inputs a node that cannot be found in the binary tree the method will catch a null reference exception.
            // If a null reference exception is cought the program will continue running without crashing when it tries to print a null.

            try
            {
                Console.WriteLine("Lowest common ancestor of {0} and {1} is {2}.", firstNode.Value, secondNode.Value, ancestor.Value);
            }
            catch (NullReferenceException)
            {
                if (firstNode == null && secondNode == null)
                {
                    Console.WriteLine("Both nodes were not found in the Binary Tree!");
                }
                else if (firstNode == null)
                {
                    Console.WriteLine("The first node was not found in the Binary Tree!");
                }
                else if (secondNode == null)
                {
                    Console.WriteLine("The second node was not found in the Binary Tree!");
                }
            }
        }
    }
}