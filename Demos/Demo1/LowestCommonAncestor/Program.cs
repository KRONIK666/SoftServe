using System;

namespace LowestCommonAncestor
{
    // Execution of the program.
    // Creating a sample tree with example values.
    // Finding the lowest common ancestor of two chosen nodes.

    public static class Program
    {
        static void Main()
        {
            Tree<string> tree =
                new Tree<string>("Big Boss",
                    new Tree<string>("Boss 1",
                        new Tree<string>("Manager 1",
                            new Tree<string>("Developer 1")),
                        new Tree<string>("Manager 2")),
                    new Tree<string>("Boss 2",
                        new Tree<string>("Manager 3",
                            new Tree<string>("Developer 2"),
                            new Tree<string>("Developer 3")),
                        new Tree<string>("Manager 4")));

            // Printing the structure of the tree.

            Console.WriteLine("Structure of the tree:");
            Console.WriteLine();
            tree.PrintDFS();

            // Picking two nodes from the tree as an input.

            Console.WriteLine();
            Console.Write("Pick the first node to compare: ");
            TreeNode<string> firstNode = new TreeNode<string>(Console.ReadLine());
            Console.Write("Pick the second node to compare: ");
            TreeNode<string> secondNode = new TreeNode<string>(Console.ReadLine());
            Console.WriteLine();

            // Instantiate an object from the class TreeNode<T>.

            TreeNode<string> ancestor = new TreeNode<string>(firstNode, secondNode);

            // Calling the method that finds the lowest common ancestor and prints the output.

            ancestor.PrintLowestCommonAncestor(firstNode, secondNode);
            Console.WriteLine();
        }
    }
}