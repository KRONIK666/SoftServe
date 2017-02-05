using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // A constructor for creating a tree.

        public Tree(T value)
        {
            this.root = new TreeNode<T>(value);
        }

        // Another constructor for creating a tree.

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        // A method that traverses and prints the tree with the Depth-First-Search (DFS) algorithm.

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

        // A method that traverses and prints the tree with the Depth-First-Search (DFS) algorithm.

        public void PrintDFS()
        {
            this.PrintDFS(this.root, string.Empty);
        }
    }
}