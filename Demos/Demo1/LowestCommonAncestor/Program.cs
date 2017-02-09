using System;

namespace LowestCommonAncestor
{
    // Program creates a sample binary tree with example values.
    // This program finds the lowest common ancestor of two nodes.

    public static class Program
    {
        static void Main()
        {
            BinaryTree<string> binaryTree =
                new BinaryTree<string>("Big Boss",
                    new BinaryTree<string>("Boss 1",
                        new BinaryTree<string>("Manager 1",
                            new BinaryTree<string>("Developer 1"),
                            null),
                        new BinaryTree<string>("Manager 2")),
                    new BinaryTree<string>("Boss 2",
                        new BinaryTree<string>("Manager 3",
                            new BinaryTree<string>("Developer 2"),
                            new BinaryTree<string>("Developer 3")),
                        new BinaryTree<string>("Manager 4")));

            // Printing the structure of the tree.

            Console.WriteLine("Structure of the tree:");
            Console.WriteLine();
            binaryTree.PrintPreorder();

            // Picking two nodes from the tree as an input.

            Console.WriteLine();
            BinaryTreeNode<string> root = binaryTree.Root;
            Console.Write("Pick the first node to compare: ");
            BinaryTreeNode<string> firstNode = new BinaryTreeNode<string>(Console.ReadLine());
            Console.Write("Pick the second node to compare: ");
            BinaryTreeNode<string> secondNode = new BinaryTreeNode<string>(Console.ReadLine());
            firstNode = binaryTree.TraverseFirstNode(firstNode);
            secondNode = binaryTree.TraverseSecondNode(secondNode);
            Console.WriteLine();

            // Instantiate an object from the class TreeNode<T>.

            BinaryTree<string> ancestor = new BinaryTree<string>(firstNode, secondNode);

            // Calling the method that finds the lowest common ancestor and prints the output.

            ancestor.PrintLowestCommonAncestor(root, firstNode, secondNode);
            Console.WriteLine();
        }
    }
}