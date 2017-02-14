using System;

namespace LowestCommonAncestor
{
    // This Program creates a sample binary tree.
    // This Program finds the lowest common ancestor of two nodes.

    public static class Program
    {
        static void Main()
        {
            // Initialising a Binary Tree.
            // Initialising an object that will represent the ancestor.

            BinaryTree<string> binaryTree = new BinaryTree<string>();
            BinaryTreeNode<string> ancestor = new BinaryTreeNode<string>();

            Console.WriteLine("Input the nodes of the Binary Tree!");
            Console.WriteLine();

            // Calling the method that fills the binary tree.

            string[] node = new string[11];

            binaryTree.InputNodes(node);
            Console.WriteLine();

            // Creating a predefined structure of a binary tree.

            binaryTree =
                new BinaryTree<string>(node[0],
                    new BinaryTree<string>(node[1],
                        new BinaryTree<string>(node[3],
                            new BinaryTree<string>(node[7]),
                            new BinaryTree<string>(node[8])),
                        new BinaryTree<string>(node[4])),
                    new BinaryTree<string>(node[2],
                        new BinaryTree<string>(node[5],
                            new BinaryTree<string>(node[9]),
                            new BinaryTree<string>(node[10])),
                        new BinaryTree<string>(node[6])));

            // Printing the structure of the binary tree.

            Console.WriteLine("Structure of the binary tree:");

            Console.WriteLine();
            binaryTree.PrintPreorder();

            // Initialising the two nodes that will be compared.

            BinaryTreeNode<string> firstNode;
            BinaryTreeNode<string> secondNode;

            do
            {
                // User inputs two node values that may be found in the binary tree.
                // The program searches if each node can be found in the binary tree.

                Console.WriteLine();

                Console.Write("Input the value of the first node: ");
                firstNode = new BinaryTreeNode<string>(Console.ReadLine());
                firstNode = binaryTree.SearchNode(binaryTree.Root, firstNode);

                Console.Write("Input the value of the second node: ");
                secondNode = new BinaryTreeNode<string>(Console.ReadLine());
                secondNode = binaryTree.SearchNode(binaryTree.Root, secondNode);

                // Calling the method that finds the lowest common ancestor.

                ancestor = binaryTree.FindLowestCommonAncestor(binaryTree.Root, firstNode, secondNode);

                // Printing the result of finding the lowest common ancestor.

                binaryTree.PrintLowestCommonAncestor(ancestor, firstNode, secondNode);

                // The above actions loop until user presses the ESC button that will stop the program.

                Console.WriteLine();
                Console.Write("Press the ESC button to stop searching or any other key to continue!");
                Console.WriteLine();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.WriteLine();
        }
    }
}