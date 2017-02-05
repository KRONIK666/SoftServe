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

            // Picking two nodes from the console to find their lowest common ancestor.

            Console.WriteLine();
            Console.WriteLine("Pick the first node to compare: ");
            Console.WriteLine("Pick the second node to compare: ");
        }
    }
}