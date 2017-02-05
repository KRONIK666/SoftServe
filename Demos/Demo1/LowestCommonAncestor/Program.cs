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

            // Picking two nodes from the tree in the console to find their lowest common ancestor.

            Console.WriteLine();
            Console.Write("Pick the first node to compare: ");
            Tree<string> firstNode = new Tree<string>(Console.ReadLine());
            Console.Write("Pick the second node to compare: ");
            Tree<string> secondNode = new Tree<string>(Console.ReadLine());
            Console.WriteLine();

            // Instantiate an object from the class Ancestor.

            Tree<string> commonAncestor = null;

            Ancestor ancestor = new Ancestor(firstNode, secondNode, commonAncestor);
            ancestor.FirstNode = firstNode;
            ancestor.SecondNode = secondNode;
            ancestor.CommonAncestor = commonAncestor;

            // Calling the method that finds the lowest common ancestor and printing the output in the console.

            ancestor.FindLowestCommonAncestor(ancestor.FirstNode, ancestor.SecondNode, ancestor.CommonAncestor);

            Console.WriteLine("Lowest common ancestor of {0} and {1} is {2}.", ancestor.FirstNode, ancestor.SecondNode, ancestor.CommonAncestor);
            Console.WriteLine();
        }
    }
}