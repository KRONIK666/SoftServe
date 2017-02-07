using System;

namespace LowestCommonAncestor
{
    // This class represents a tree data structure.

    public class Tree<T>
    {
        private TreeNode<T> root;

        public TreeNode<T> Root
        {
            get { return this.root; }
        }

        // A constructor where nodes get a value.

        public Tree(T value)
        {
            this.root = new TreeNode<T>(value);
        }

        // A constructor for adding a child to a node.

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        // A method that traverses and prints the tree structure with the Depth-First-Search algorithm.

        private void PrintDFS(TreeNode<T> root, string spaces)
        {
            Console.WriteLine(spaces + root.Value);
            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                PrintDFS(child, spaces + "   ");
            }
        }

        // This method invokes the private PrintDFS() method.

        public void PrintDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }
    }
}