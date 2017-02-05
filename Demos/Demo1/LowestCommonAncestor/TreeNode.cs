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
        private List<TreeNode<T>> children;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
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

        // A method for adding a child to a node.

        public void AddChild(TreeNode<T> child)
        {
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
}