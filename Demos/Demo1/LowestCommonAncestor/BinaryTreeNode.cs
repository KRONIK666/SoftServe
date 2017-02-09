namespace LowestCommonAncestor
{
    // This class represents a tree node.

    public class BinaryTreeNode<T>
    {
        private T value;
        private BinaryTreeNode<T> leftChild;
        private BinaryTreeNode<T> rightChild;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public BinaryTreeNode<T> LeftChild
        {
            get { return this.leftChild; }
            set { this.leftChild = value; }
        }

        public BinaryTreeNode<T> RightChild
        {
            get { return this.rightChild; }
            set { this.rightChild = value; }
        }

        // A constructor that keeps the children of a tree node.

        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild)
        {
            this.value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public BinaryTreeNode(T value)
            : this(value, null, null)
        {

        }
    }
}