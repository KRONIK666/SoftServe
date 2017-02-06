using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    new Tree<string>("Boss1",
                        new Tree<string>("Manager1",
                            new Tree<string>("Developer1")),
                        new Tree<string>("Manager2")),
                    new Tree<string>("Boss2",
                        new Tree<string>("Manager3",
                            new Tree<string>("Developer2"),
                            new Tree<string>("Developer3")),
                        new Tree<string>("Manager4")));

            // Printing the structure of the tree.

            Console.WriteLine("Structure of the tree:");
            Console.WriteLine();
            tree.PrintDFS();

            // Picking two nodes from the tree as an input into the console.

            Console.WriteLine();
            Console.Write("Pick the first node to compare: ");
            TreeNode<string> firstNode = new TreeNode<string>("Boss1");
            Console.Write("Pick the second node to compare: ");
            TreeNode<string> secondNode = new TreeNode<string>("Boss2");
            TreeNode<string> parent = null;
            Console.WriteLine();

            // Instantiate an object from the class TreeNode<T>.

            TreeNode<string> ancestor = new TreeNode<string>(parent, firstNode, secondNode);
            ancestor.Parent = parent;
            ancestor.FirstNode = firstNode;
            ancestor.SecondNode = secondNode;

            // Calling the methods that find the lowest common ancestor and print the output in the console.

            ancestor.FindLowestCommonAncestor(ancestor.Parent, ancestor.FirstNode, ancestor.SecondNode);
            ancestor.PrintLowestCommonAncestor();
        }
    }
}