namespace FindingLowestCommonAncestor
{
    // This class represents a binary tree node.
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

        // Constructor without parameters that constructs a binary tree node.
        public BinaryTreeNode()
        {

        }

        // Constructs a binary tree node that has children.
        public BinaryTreeNode(T value, BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild)
        {
            this.value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        // Constructs a binary tree node that has no children.
        public BinaryTreeNode(T value)
            : this(value, null, null)
        {

        }
    }
}