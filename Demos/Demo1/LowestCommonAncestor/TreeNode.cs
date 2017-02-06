using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestor
{
    // This class represents a tree node.

    public class TreeNode<T>
    {
        private T value;
        private TreeNode<T> parent;
        private TreeNode<T> firstNode;
        private TreeNode<T> secondNode;
        private List<TreeNode<T>> children;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public TreeNode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public TreeNode<T> FirstNode
        {
            get { return firstNode; }
            set { firstNode = value; }
        }

        public TreeNode<T> SecondNode
        {
            get { return secondNode; }
            set { secondNode = value; }
        }

        public int ChildrenCount
        {
            get { return this.children.Count; }
        }

        // A constructor that creates a tree node.

        public TreeNode(T value)
        {
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        // A constructor that is called for the comparing of two nodes.

        public TreeNode(TreeNode<T> parent, TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
            this.parent = parent;
            this.firstNode = firstNode;
            this.secondNode = secondNode;
        }

        // A method for adding a child to a node.

        public void AddChild(TreeNode<T> child)
        {
            this.children.Add(child);
        }

        // A method for getting a child's index.

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }

        // The method where the lowest common ancestor algorithm is realized.

        public TreeNode<T> FindLowestCommonAncestor(TreeNode<T> parent, TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
            if (parent == null)
            {
                return null;
            }
            if (parent == firstNode || parent == secondNode)
            {
                return parent;
            }

            TreeNode<T> leftPath = FindLowestCommonAncestor(parent, firstNode, secondNode);
            TreeNode<T> rightPath = FindLowestCommonAncestor(parent, firstNode, secondNode);

            if ((leftPath == firstNode && rightPath == secondNode) || (leftPath == secondNode && rightPath == secondNode))
            {
                return parent;
            }
            return (leftPath != null) ? leftPath : rightPath;
        }

        private void PrintLowestCommonAncestor(TreeNode<T> parent, TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
            Console.WriteLine("Lowest common ancestor of {0} and {1} is {2}.", firstNode, secondNode, parent);
            Console.WriteLine();
        }

        public void PrintLowestCommonAncestor()
        {
            this.PrintLowestCommonAncestor(this.parent, this.firstNode, this.secondNode);
        }
    }
}