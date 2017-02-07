using System;
using System.Collections.Generic;

namespace LowestCommonAncestor
{
    // This class represents a tree node.

    public class TreeNode<T>
    {
        private T value;
        private TreeNode<T> ancestor;
        private TreeNode<T> firstNode;
        private TreeNode<T> secondNode;
        private List<TreeNode<T>> children;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public TreeNode<T> Ancestor
        {
            get { return ancestor; }
            set { ancestor = value; }
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

        // A constructor that keeps the children of a tree node.

        public TreeNode(T value)
        {
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        // A constructor that is used to create an object of the class.

        public TreeNode(TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
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
        // The method also prints the result as an output.

        public void PrintLowestCommonAncestor(TreeNode<T> firstNode, TreeNode<T> secondNode)
        {
            List<TreeNode<T>> nodes = new List<TreeNode<T>>();
            Queue<TreeNode<T>> visitedNode = new Queue<TreeNode<T>>();

            visitedNode.Enqueue(new TreeNode<T>(firstNode.Value));

            while (visitedNode.Count > 0)
            {
                TreeNode<T> currentNode = visitedNode.Dequeue();
                nodes.Add(currentNode);

                foreach (TreeNode<T> child in nodes)
                {
                    visitedNode.Enqueue(child);
                }
            }

            if (nodes.Contains(secondNode))
            {
                ancestor = firstNode;
            }

            Console.WriteLine("Lowest common ancestor of {0} and {1} is {2}.", firstNode.Value, secondNode.Value, ancestor.Value);
        }
    }
}