using System;

namespace LowestCommonAncestor
{
    // This class represents a tree data structure.

    public class BinaryTree<T>
    {
        private BinaryTreeNode<T> root;
        private BinaryTreeNode<T> firstNode;
        private BinaryTreeNode<T> secondNode;

        public BinaryTreeNode<T> Root
        {
            get { return this.root; }
        }

        public BinaryTreeNode<T> FirstNode
        {
            get { return firstNode; }
            set { firstNode = value; }
        }

        public BinaryTreeNode<T> SecondNode
        {
            get { return secondNode; }
            set { secondNode = value; }
        }

        // A constructor where nodes get a value.
        // A constructor for adding a child to a node.
        // A constructor that is used to create an object of the class.

        public BinaryTree(T value, BinaryTree<T> leftChild, BinaryTree<T> rightChild)
        {
            BinaryTreeNode<T> leftChildNode = leftChild != null ? leftChild.root : null;
            BinaryTreeNode<T> rightChildNode = rightChild != null ? rightChild.root : null;
            this.root = new BinaryTreeNode<T>(value, leftChildNode, rightChildNode);
        }

        public BinaryTree(T value)
            : this(value, null, null)
        {

        }

        public BinaryTree(BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode)
        {
            this.firstNode = firstNode;
            this.secondNode = secondNode;
        }

        // A method that traverses and prints the tree structure with the Depth-First-Search algorithm.

        private void PrintPreorder(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.Value);
            PrintPreorder(root.LeftChild);
            PrintPreorder(root.RightChild);
        }

        public void PrintPreorder()
        {
            PrintPreorder(this.root);
        }

        public BinaryTreeNode<T> TraverseFirstNode(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode)
        {
            if (root == null)
            {
                return null;
            }
            else if (object.Equals(root.Value, firstNode.Value))
            {
                firstNode = root;
                return firstNode;
            }
            else
            {
                TraverseFirstNode(root.LeftChild, firstNode);
                TraverseFirstNode(root.RightChild, firstNode);
            }
            return root;
        }

        public BinaryTreeNode<T> TraverseFirstNode(BinaryTreeNode<T> firstNode)
        {
            return TraverseFirstNode(this.root, firstNode);
        }

        public BinaryTreeNode<T> TraverseSecondNode(BinaryTreeNode<T> root, BinaryTreeNode<T> secondNode)
        {
            if (root == null)
            {
                return null;
            }
            else if (object.Equals(root.Value, secondNode.Value))
            {
                secondNode = root;
                return secondNode;
            }
            else
            {
                TraverseSecondNode(root.LeftChild, secondNode);
                TraverseSecondNode(root.RightChild, secondNode);
            }
            return root;
        }

        public BinaryTreeNode<T> TraverseSecondNode(BinaryTreeNode<T> secondNode)
        {
            return TraverseSecondNode(this.root, secondNode);
        }

        // The method where the lowest common ancestor algorithm is realized.
        // The method also prints the result as an output.

        public BinaryTreeNode<T> FindLowestCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode)
        {
            if (root == null)
            {
                return null;
            }

            if (root == firstNode || root == secondNode)
            {
                return root;
            }

            BinaryTreeNode<T> left = FindLowestCommonAncestor(root.LeftChild, firstNode, secondNode);
            BinaryTreeNode<T> right = FindLowestCommonAncestor(root.RightChild, firstNode, secondNode);

            if (left != null && right != null)
            {
                return root;
            }

            if (left != null)
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        public void PrintLowestCommonAncestor(BinaryTreeNode<T> root, BinaryTreeNode<T> firstNode, BinaryTreeNode<T> secondNode)
        {
            BinaryTreeNode<T> ancestor = FindLowestCommonAncestor(root, firstNode, secondNode);
            Console.WriteLine("Lowest common ancestor of {0} and {1} is {2}.", firstNode.Value, secondNode.Value, ancestor.Value);
        }
    }
}